    public string val(string a)
    {
        if(Request.QueryString[a] != null)
           return Request.QueryString[a].ToString();
        
        return string.Empty;
    }
