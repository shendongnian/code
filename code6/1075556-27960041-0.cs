    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    
    public class ScoreManager : MonoBehaviour 
    {
    	public static float playerScore;
    	public Text scoreCount;
    
    	public void Update()
    	{
    		ScoreController ();
    	}
    
    	public void ScoreController()
    	{
    		scoreCount.text = "Score: " + playerScore;
    		Debug.Log ("Score: " + playerScore);
    	}
    }
    using UnityEngine;
    using System.Collections;
    
    public class HarmEnemies : MonoBehaviour 
    {
    	public float enemyHealth;
    	public float enemyCurHealth;
    	public float playerDamage;
    	
    	public void Start()
    	{
    		enemyCurHealth = enemyHealth;
    	}
    
    	public void OnTriggerEnter(Collider theCollision)
    	{
    		if(theCollision.tag == "Fireball")
    		{
    			enemyCurHealth = enemyCurHealth - playerDamage;
    			Destroy (theCollision);
    		}
    
    		if(enemyCurHealth <= 0)
    		{
    			ScoreManager.playerScore = (ScoreManager.playerScore + 1);
    			Destroy (this.gameObject);
    		}
    	}
    }
