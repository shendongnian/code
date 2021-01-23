        int score; 
        bool isDead=false;
        
        
         void OnGUI () {
            if(isDead) //make this true when player dies
                GUI.Label (new Rect (0,0,100,50),score.ToString());
            }
        
        public void Damage(int damageCount)
            {
                hp -= damageCount;
        
                if (hp <= 0)
                {
                    // Dead!
                    Destroy(gameObject);
                    score++;  //increase score
                }
            }
