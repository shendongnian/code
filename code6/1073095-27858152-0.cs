    private string name;
    public string Name 
    {
        get
        {
            return name;
        }
        set
        {           
            CheckName(value); // Or whatever are you check functions
            name = value;
            PropertyChanged("Name");
        }
    }
