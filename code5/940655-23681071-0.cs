    private string _name = "";
    public string Name { 
    get
    {
        if(string.IsNullOrEmpty(_name))
        {
            return "Unnamed";
        }
        else
        {
            return _name;
        }
    }
     set
    {
        _name = value;
    }
    }
