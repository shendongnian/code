    private const float TIME_DELAY = .5f;
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            coin++; 
            audio.PlayOneShot(coinSound);
            StartCoroutine(Ding());
            Destroy(gameObject, TIME_DELAY * 2);
    
        }
    }
    IEnumerator Ding()
    {
         yield return new WaitForSeconds(TIME_DELAY);
    }
    
