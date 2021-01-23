    private Dictionary< string,object > properties;
    public Dictionary<string, object> Properties
    {
        get { return properties; }
        set { properties = value; }
    }
    private int x1;
    public int X1
    {
        get { return x1; }
        set 
        { 
            x1 = value; 
            UpdateDictionaryValue(); // Updates the current X3 Value
            OnPropertyChanged("X1");
            OnPropertyChanged("Properties");
        }
    } 
    public void UpdateDictionaryValue()
    {
        if (Properties.ContainsKey("X3"))
        {
            Properties["X3"] = X1 + X2;
        }
    }
