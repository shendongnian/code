    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("GameOverScene");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            StartCoroutine(WaitAndDie());         
            return;
        }
    
    }
    }
