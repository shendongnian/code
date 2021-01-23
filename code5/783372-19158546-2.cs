    public static T GetQueryString<T>(ref T caller, string queryString)
    {
        if (HttpContext.Current.Request.QueryString[queryString] != null)
        {
            T type = (T)Convert.ChangeType(HttpContext.Current.Request.QueryString[queryString], typeof(T));
                
            return type;
        }
    }
    GetQueryString(ref t1, "name");
