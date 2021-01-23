    void Update(){
      if(projectile.GetComponent <SpringJoint2D>() && projectile.velocity.sqrMagnitude < resetSpeedSqr)
            {
                    if (BallCount <= 0 ); 
                      {
                              ObjeyiKlonla();
                      }
            }   
    }
