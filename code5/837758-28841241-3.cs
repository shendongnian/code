    using UnityEngine;
    using System.Collections;
    public class PlayerController : MonoBehaviour {
	    public PlayerCharacter player;
	
	    void Update () 
	    {
		    if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		    {
			    player.Movement(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*player.walkSpeed*Time.deltaTime);
		    }
	    }
    }
 
