    void OnCollisionEnter(Collision myCollision)
    {
        GameObject g = myCollision.gameObject;        
        if(g.tag == "wall")
           Destroy(g);
    }
    
    
