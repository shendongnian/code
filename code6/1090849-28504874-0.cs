    public GameObject prefabs[];
    List<GameObject> objects = new List<GameObject>();
    void Start() {
        for(GameObject prefab in prefabs) {
            GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject; // Replace Vector3.zero by actual position
            objects.Add(go); // Store objects to access them later: total enemies count, restart game, etc.
        }
    }
