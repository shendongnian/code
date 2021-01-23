    private String _varUserName //may be you are missing this here
    
    public string UserName
    {
        get{return _varUserName;} //set get value to a property
        set{_varUserName = value;}
    }
    //Auto Implemented property
    public string UserName{get;set;} //doing nothing just setting a property
