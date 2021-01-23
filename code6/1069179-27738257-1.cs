    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            coin++; 
            StartCoroutine(Ding());  
        }
    }
    IEnumerator Ding()
    {
        audio.PlayOneShot(coinSound);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    
