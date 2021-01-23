    public UILabel prefab; // assign this in the inspector
    protected virtual void Start()
    {
        Debug.Log(prefab.text);
        
        ...
    }
