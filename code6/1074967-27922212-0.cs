    public UILabel prefab;
    protected virtual void Start()
    {
        GameObject instance = (GameObject) Instantiate(prefab);
        UILabel uiLabel = instance.GetComponent<UILabel>();
        Debug.Log(uiLabel.text);
        
        ...
    }
