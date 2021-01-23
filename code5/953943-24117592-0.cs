    void OnTriggerEnter(Collider otherObject)
    {
        StartCoroutine(DestroyAllEnemies());
    }
    
    IEnumerator DestroyAllEnemies()
    {
        for(int i = 1; i<=numenemies;i++)
        {
            string tag="Enemy"+i;
            destroyenemy=GameObject.FindGameObjectWithTag(tag);
            Destroy(destroyenemy);
            yield return new WaitForSeconds (1);
        }
     }
