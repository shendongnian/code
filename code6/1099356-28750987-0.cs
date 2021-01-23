    float speedBoostTime = 0;
    
    void SpeedUp()
    {
        speed *= 2;
        speedBoostTime = 3; // seconds
    }
    
    void Update()
    {
        while ( speedBoostTime > 0 )
        {
            speedBoostTime -= Time.deltaTime;
            if ( speedBoostTime <= 0 ) speed /= 2;
        }
    }
