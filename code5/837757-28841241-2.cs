    using UnityEngine;
    using System.Collections;
    [System.Serializable]
    public class Ammo 
    {
	    public GameObject ammoObject;
	    public int damage;
	    public float moveSpeed;
	    public Ammo(GameObject aO, int d, float mS)
	    {
		    ammoObject = GameObject.Instantiate(aO)as GameObject;
		    damage = d;
		    moveSpeed = mS;
	    }
	    public IEnumerator Movement (Vector3 target)
	    {
		    while(ammoObject != null)
		    {
			    ammoObject.transform.position = ammoObject.transform.forward+target*moveSpeed*Time.deltaTime;
			
			    yield return null;
		    }
		
	    }
    }
    public enum AmmoType
    {
	    FireBallBall,
	    RidiculousHugeBullet,
	    MegaAwesomeMagicPowerEffect,
	    None
    }
