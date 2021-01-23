    public float minTime = 1;
    public float maxTime = 3;
    public int minSpawn = 1;
    public int maxSpawn = 4;
    public Bounds spawnArea; //set these bounds in the inspector
    public GameObject enemyPrefab;
    
    private spawnTimer = 0;
    
    Vector3 randomWithinBounds(Bounds r) {
        return new Vector3(
            Random.Range(r.min.x, r.max.x),
            Random.Range(r.min.y, r.max.y),
            Random.Range(r.min.z, r.max.z));
    }
    
    void Update() {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0) {
            spawnTimer += Random.Range(minTime, maxTime);
            int randomSpawnCount = Random.Range(minSpawn, maxSpawn);
            for(int i = 0; i < randomSpawnCount; i++) {
                Instantiate(transform.transformPoint(enemyPrefab), randomWithinBounds(spawnArea), Quaternion.identity);
            }
        }
    }
    
    //bonus: this will show you the spawn area in the editor
    
    void OnDrawGizmos() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.yellow;
        Gizmos.drawWireCube(spawnArea.center, spawnArea.size);
    }
