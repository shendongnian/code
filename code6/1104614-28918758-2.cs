    void Awake()
    {
        displayObjects = GameObject.Find("DisplayObjects");
        displayRotation = displayObjects.GetComponent<RotateForDisplay>();
    }
