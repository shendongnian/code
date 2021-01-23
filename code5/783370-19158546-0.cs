    public static T GetQueryString<T>(this T caller, string queryString)
    {
        if (HttpContext.Current.Request.QueryString[queryString] != null)
        {
            T type = (T)Convert.ChangeType(HttpContext.Current.Request.QueryString[queryString], typeof(T));
                
            return type;
        }
    }
    string t1 = string.Empty;
    t1 = t1.GetQueryString("name"); // return the value and reassign
