    public string ParamSearch1
    {
        get
        {
           return GetValueFromQueryString();     
        }
    }
    private string GetValueFromQueryString([CallerMemberName] string keyName = "")
    {
        return string.IsNullOrEmpty(Request.QueryString[keyName]) ? "" : Request.QueryString[keyName];       
    }
