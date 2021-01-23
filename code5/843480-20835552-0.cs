     void OnTriggerEnter(Collider c)
        {
           if(!dead && (c.gameObject.name =="barrel" || c.gameObject.name == "ground"))
           {
             Destroy(initialSpawn); 
             dead = true;
           }
        }
