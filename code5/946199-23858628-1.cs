    private isIdle = false;
    private float previousTime;
    private const float IDLE_TIME = 5.0f;
    IEnumerator Idle()
    {
        // check if player is idling on the ground
        if(grounded && (_controller.velocity.x == 0))
        {
            isIdle = true;
            previousTime = Time.timeSinceLevelLoad();
        }
        idleIndex = IdleRandom();
        _animator.SetInteger("IdleIndex", idleIndex);
        _animator.SetTrigger("Idle");
    }
    void FixedUpdate()
    {
        // Count time here.
        if(isIdle && Time.timeSinceLevelLoad - previousTime > IDLE_TIME)
        {
            // Play animation here.
            
            // Reset previousTime.
            previousTime = Time.timeSinceLevelLoad;  
        }
    }
