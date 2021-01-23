    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyStats stats = col.GetComponent<EnemyStats>();
            
            if (stats)
            {
                stats.ReduceHealth(bulletPower);
    
                if (stats.IsDead())
                {
                    scoreManager.Points += (2 * playerController.currentWave);
                    Destroy(col.gameObject);
                }
            }
        }
    }
