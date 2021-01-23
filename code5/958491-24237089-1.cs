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
            OnPropertyChanged("X1");
            OnPropertyChanged("Properties");
        }
    } 
