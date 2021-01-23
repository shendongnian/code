    void Start()
    {
        StartCoroutine(SpawnAll());
    }
    public IEnumerator SpawnAll()
    {
        foreach (GameObject obj in objectsToSpawn)
        {
            GameObject instance = Instantiate(obj) as GameObject;
            // wait for object, see below
        }
    }
