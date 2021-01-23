    [WebGet(UriTemplate = "RetrieveInformation")]
    public string Get1()
    {
        return RetrieveInfo(1,2,3);
    }
    
    [WebGet(UriTemplate = "RetrieveInformation/param1/{param1}")]
    public string GetP1(int param1)
    {
        return RetrieveInfo(param1,2,3);
    }
    
    [WebGet(UriTemplate = "RetrieveInformation/param1/{param1}/param2/{param2}")]
    public string GetP1P2(int param1, int param2)
    {
        return RetrieveInfo(param1,param2,3);
    }
    
    [WebGet(UriTemplate = "RetrieveInformation/param1/{param1}/param3/{param3}")]
    public string GetP1P3(int param1, int param3)
    {
        return RetrieveInfo(param1,2,param3);
    }
    
    private string RetrieveInfo(int p1, int p2, int p3)
    {
        ...
    }
