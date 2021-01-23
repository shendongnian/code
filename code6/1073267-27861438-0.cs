    public GameObject prefab; // Drag and drop prefab to component in unity
    // When trigger is triggered
    void OnTriggerEnter(Collider col) 
    {
        Instantiate(prefab, new Vector3(0,0,0), Quaternion.Identity);
    }
