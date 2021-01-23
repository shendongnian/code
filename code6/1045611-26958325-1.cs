    private string _path2 = null;
    
    public string Path1 {get;set;}
    public string Path2 
    {
    get {
    
    if (String.IsNullOrEmpty(_path2))
    {
    return Path1 + "bla"; //Or your default value
    }
    else 
    {
    return _path2;
    }
    
    }
    
    set 
    {
    _path2 = value;
    }
    
    }
