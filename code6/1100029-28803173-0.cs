    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Turret : MonoBehaviour
    {
    	[SerializeField]
    	public float turnRateRadians = 2 * Mathf.PI;
    	
    	[SerializeField]
    	Transform turretTop;
    	
    	[SerializeField]
    	Transform bulletSpawnPoint;
    	
    	private Enemy target;
    
    	void Update()
    	{
    		TargetEnemy();
    	}
    
    	void TargetEnemy()
    	{
    		if (target == null || target.health <= 0)
    			target = Enemy.GetClosestEnemy(turretTop, enemy => enemy.health > 0);
    
    		if (target != null)
    		{
    			Vector3 targetDir = target.transform.position - transform.position;
    			// Moving in 2D Plane...
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
    
    	public static Enemy GetClosestEnemy(Transform referenceTransform, System.Predicate<Enemy> filter=null)
    	{
    //		return allEnemies[0]; // Left as an exercise for the reader
    	}
    }
