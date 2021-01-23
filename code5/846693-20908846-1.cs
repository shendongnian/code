    private string _name;
    public string Name
    {
        get { return name; }
        set 
        { 
            name = value; 
            RaisePropertyChanged("Name"); 
        }
    }
