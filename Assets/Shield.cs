﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    [Header("Set in Inspector")]
    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamically")]
    public int levelShown = 0;

    //this non-piblic varibale will not appear in the inspector
    Material    mat;




    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    // Update is called once per frame
    void Update()
    {
        //read the current shield level from the Hero Singleton
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        //if this is different from level showb...
        if(levelShown != currLevel)
        {
            levelShown = currLevel;
            //Adjust the texture offset to show different shield level
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
                   
         }
        //rotate the shield a bit every framw in a time-based way
        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
