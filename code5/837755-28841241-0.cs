    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    [System.Serializable]
    public class PlayerCharacter
    {
	    //public NetworkPlayer newtWorkPlayer;
	    public int playerID;
	    public GameObject characterObject;
	    public string characterName;
	    public float walkSpeed;
	    public int health;
	    public Vector3 spawnPosition;
	    public List<Weapon> weapons = new List<Weapon>();
	    public Weapon equipedWeapon;
	
	    public PlayerCharacter()
	    {
		    playerID = 0;
		    characterObject = null;
		    characterName = "";
		    walkSpeed = 0;
		    health = 0;
	    }
	
	     public PlayerCharacter(/*NetworkPlayer nP,*/ int pID, GameObject cO, string cN, float wS, int h, Vector3 sP)
	    {
		     //newtWorkPlayer = nP;
		     playerID = pID;
		     characterObject = Network.Instantiate(cO, sP, Quaternion.identity, 0)as GameObject;//GameObject.Instantiate(cO,sP,Quaternion.identity)as GameObject;
		    characterName = cN;
		    walkSpeed = wS;
		    health = h;
		    spawnPosition = sP;
	    }
	
	    public void TakeDamage (int takeDamage)
	    {
		    health -= takeDamage;
	    }
	
	    public void Movement (Vector3 target)
	    {
		    characterObject.transform.position += target;
	    }
    }
