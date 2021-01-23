    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Turret : MonoBehaviour
    {
    	[SerializeField]
    	private float turnRateRadians = 2 * Mathf.PI;
    	
    	[SerializeField]
    	private Transform turretTop; // the gun part that rotates
    	
    	[SerializeField]
    	private Transform bulletSpawnPoint;
    	
    	private Enemy target;
    
    	void Update()
    	{
    		TargetEnemy();
    	}
    
    	void TargetEnemy()
    	{
    		if (target == null || target.health <= 0)
    			target = Enemy.GetClosestEnemy(turretTop, filter: enemy => enemy.health > 0);
    
    		if (target != null)
    		{
    			Vector3 targetDir = target.transform.position - transform.position;
    			// Rotating in 2D Plane...
    			targetDir.y = 0.0f;
    			targetDir = targetDir.normalized;
    			
    			Vector3 currentDir = turretTop.forward;
    			
    			currentDir = Vector3.RotateTowards(currentDir, targetDir, turnRateRadians*Time.deltaTime, 1.0f);
    				
    			Quaternion qDir = new Quaternion();
    			qDir.SetLookRotation(currentDir, Vector3.up);
    			turretTop.rotation = qDir;
    		}
    	}
    }
    
    class Enemy : MonoBehaviour
    {
    	public float health = 0;
    
    	private static HashSet<Enemy> allEnemies = new HashSet<Enemy>();
    
    	void Awake()
    	{
    		allEnemies.Add(this);
    	}
    
    	void OnDestroy()
    	{
    		allEnemies.Remove(this);
    	}
    
    	/// <summary>
    	/// Get the closest enemy to some transform, optionally filtering
    	/// (for example, enemies that aren't dead, or enemies of a certain type).
    	/// </summary>
    	public static Enemy GetClosestEnemy(Transform referenceTransform, System.Predicate<Enemy> filter=null)
    	{
    	    // Left as an exercise for the reader.
    	    // Remember not to use Vector3.Distance in a loop if you don't need it. ;-)
    //		return allEnemies[0];
    	}
    }
