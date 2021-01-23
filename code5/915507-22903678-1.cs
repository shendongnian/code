    var postRequest = (HttpWebRequest)WebRequest.Create(url); 
               
    postRequest.ContentType = "application/x-www-form-urlencoded";// Not needed for get requests
    postRequest.Method = "POST"; // Set 'GET' for get requests
    var allKeys = postRequest.Headers.AllKeys;
    if (sessionCookie == null)
    {
        postRequest.CookieContainer = new CookieContainer();
    }
    else
    {
        postRequest.CookieContainer = sessionCookie;
    }
