    public SphereCollider sphereCollider;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //or however you want to call it.
        {
            sphereCollider = gameObject.GetComponent<SphereCollider>();
            sphereCollider.enabled = false;
        }
    }
