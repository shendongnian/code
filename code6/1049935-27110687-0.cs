    string URI = "http://www.server.com/login";
    string myParameters = "username=value1&password=value2";
    
    using (WebClient wc = new WebClient())
    {
        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        string HtmlResult = wc.UploadString(URI, myParameters);
    }
