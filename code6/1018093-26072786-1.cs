     private GameObject hitobject ; 
     void OnCollisionEnter(Collision myCollision)
     {
       hitobject = myCollision.gameObject;
        if (hitobject.tag == "wall")
          {
           Destroy(hitobject);
          }
    }
