    using UnityEngine;
    using System.Collections;
    
    public class SimplePlayer0 : MonoBehaviour
    {
      Animator anim;
    
      //Lives
      private int lives = 3;
      private bool isImmune;
      public float immuneCounter;
      public float immuneTime;
    
      //PROPERTIES
    
    
      //putting some logic in getters-setters of your properties
      public int Lives 
      {
        get { return lives; }
        set {
        	if(lives != value){
        		lives = value;
        		if(IsDead){
        			Dead();
        		}else{
        			IsImmune = true;				
        		}
        	}
     	}
      }
    
      private void Dead()
      {
      	Application.LoadLevel(8);
      }
    
      public bool IsImmune
      {
        get { return isImmune; }
        set { 
        	if(isImmune != value){
        		isImmune = value; 
        		anim.SetBool("Immume", isImmune);
        		//ternary operator - a shorthand for if-else statement
        		immuneCounter = isImmune ? immuneTime : 0;
        	}
        }
      }
    
      public bool IsDead{
      	get{
      		return Lives <= 0;
      	}
      }
    
      void Start ()
      {
        anim = GetComponent<Animator>();
      }
    
      void Update()
      {
        if (IsImmune)
        {
          immuneCounter -= Time.deltaTime;
        }
    
        if (immuneCounter <= 0)
        {
          IsImmune = false; 
        }
    }
