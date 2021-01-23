    using UnityEngine;
    using System.Collections;
    
    public class Player : MonoBehaviour
    {
    	private int health;
    
    	public Player()
    	{
    		health = 100;
    	}
    
    	public void Knockback(float amount)
    	{
    		gameObject.rigidbody.AddForce(Vector3.back * amount)
    	}
    }
