    public EnemySpawner enemyspawner;
    void function()
    {
       enemyspawner=gameObject.GetComponent<EnemySpawner>();
       enemyspawner.setEnemies();
    }
