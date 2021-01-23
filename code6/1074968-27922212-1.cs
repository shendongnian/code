    public UILabel prefab; // assign this in the inspector
    protected virtual void Start()
    {
        GameObject instance = (GameObject)Instantiate(prefab);
        UILabel uiLabel = instance.GetComponent<UILabel>();
        Debug.Log(uiLabel.text);
        
        ...
    }
