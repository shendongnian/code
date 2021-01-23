    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class Tito : MonoBehaviour {
	public float jumpspeed = 50;  //JUMP HEIGHT
	public bool grounded = false; // TRUE = TITO IS ON THE GROUND
	public int jumps = 0; // COUNTER TO CHECK THE AMOUNT OF JUMPS
	public int maxJumps = 2; // MAX EXTRA JUMPS
	void OnCollisionEnter2D(Collision2D coll) 
	{
	// CHECK TO SEE IF GROUNDED //
		if (coll.gameObject.name == "Ground")
		{
			Debug.Log ("Grounded");
			grounded = true;
			jumps = 0;
		}
	}
	void Update()
	{
	if (Input.GetKeyDown(KeyCode.Space) && jumps < maxJumps)
		{
			Jump();
		}
	}
	
	void Jump()
		{
			rigidbody2D.velocity = new Vector3 (0, jumpspeed, 0);
			jumps = jumps +1;
		}
    }
