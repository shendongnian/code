    void OnCollisionEnter2D(Collision2D other)
    {
        Invoke ("Die", 2.0f);
    }
    
    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
