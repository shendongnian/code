    public float respawnTimeOut = 2F;
    public static bool dead = false;
            
    private float timeSinceDeath = 0F;
    private Transform initialSpawn;
    private Transform respawn;
                    
    void Start()
    {
       initialSpawn = Instantiate(respawn, new Vector3(0,7,0), Quaternion.identity) as Transform;
       initialSpawn.parent = transform;
    }
                    
    void Update () 
    {
        if (dead == true)
        {                
            if(timeSinceDeath >= respawnTimeOut)    
            {
               initialSpawn = Instantiate(respawn, new Vector3(4, 7, 0), Quaternion.identity) as Transform; 
               initialSpawn.parent = transform;                    
               dead = false;
               timeSinceDeath = 0F;
               Debug.Log("test working");
            }
            else
            {
                // Update death timer
                timeSinceDeath += Time.deltaTime;
            }
         }
    }
                    
    void OnTriggerEnter(Collider c)
    {
         if(c.gameObject.name =="barrel" || c.gameObject.name == "ground") 
         {
             Destroy(initialSpawn); 
             dead = true;
         }
    }
