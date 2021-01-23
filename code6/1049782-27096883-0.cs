    private Transform dropPoint;   
    void Awake()
    {
        dropPoint = transform.Find("DropPoint");
    }
    public void DeathState()
    {
        if(randomBuff == 1)
           Instantiate(dropHpBuff, dropPoint.position, dropPoint.rotation); 
    }
