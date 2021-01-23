    //assume that the NameValueCollection object has already been created and populated  
    var redirectUrl = string.Format("{0}?{1}", "DoPost.aspx", BuildQueryString(data));
    Response.Redirect(redirectUrl, true);
    public static string BuildQueryString(NameValueCollection data)
    {
        // create query string with all values
        return string.Join("&", data.AllKeys.Select(key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(data[key]))));
    }
