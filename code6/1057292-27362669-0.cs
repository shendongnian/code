    public int GetIntFromQueryString(string key)
    {
        int result = int.MinValue;
        if(Request.QueryString[key] != null)
        {
            int.TryParse(Request.QueryString[key].ToString(), out result);
        }
        return result;
    }
