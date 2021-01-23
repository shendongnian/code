    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using System.Collections;
    
    namespace Assets.Scripts
    {
    	public static class MyGameObjManager 
    	{
    		private static bool alreadyLoaded;
    		public static GameObject myHero { get; private set; }
    		public static GameObject myWeapon {get; private set;}
    
    		public static void LoadObjects()
    		{
    			if (alreadyLoaded)
    				return;
    			
    			// Load the resource which is RELATIVE to the "Resources" path...
    			myHero = (GameObject)Resources.Load("Prefab/Hero");
    
    			// This OTHER appears to load at a SPECIFIC Path allowing it to go to the root level ASSETS
    			myWeapon = (GameObject)Resources.LoadAssetAtPath("Assets/Resources/Prefab/Weapon", typeof(GameObject));
    
    			alreadyLoaded = true;
    		}
    
    	}
    
    	public class GameMgr2 : MonoBehaviour
    	{
    		public static GameObject GetHero()
    		{
    			MyGameObjManager.LoadObjects();
    			return (GameObject)Instantiate(MyGameObjManager.myHero, new Vector3(0, 0, 0), new Quaternion());
    		}
    	
    		public static GameObject GetWeapon()
    		{
    			MyGameObjManager.LoadObjects();
    			return (GameObject)Instantiate(MyGameObjManager.myWeapon, new Vector3(0, 0, 0), new Quaternion());
    		}
    	}
    }
