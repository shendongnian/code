    private string myValue = "default value";
    
    public string MyValue {
        get { return myValue; }
        set {
            if (null != value) { myValue = value; }
        }
    }
