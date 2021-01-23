     Action<float> takeDamage;
     public void SetWalk () { takeDamage = TakeWalkingDamage;}
         
     public void TakeDamage(float damage)
     {
        takeDamage(damage);
     }
  
