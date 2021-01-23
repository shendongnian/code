    void OnCollisionEnter2D(Collision2D other)
    {
        Thread Dying = new Thread(()=>Die());
        Dying.Start(); //start a death in new thread so can do other stuff in main thread
    }
    void Die()
    {
        Thread.Sleep(2000); //wait for 2 seconds
        Application.LoadLevel(Application.loadedLevel);
    }
