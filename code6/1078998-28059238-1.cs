      void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                audio.Play();
                float timer = 0;
                do{timer += Time.deltaTime;}while(timer != 1)
                gameObject.SetActive(false);
            }
        }
