    HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(string.Format("https://{0}/login", server));
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    bool loginSuccess = false;
    if (response.StatusCode == HttpStatusCode.OK)
    {
        //If there's a cookie in the response, it means login successful, 
        //and the cookie is the one returned by the server that can be used to identify
        //the client when calling Authorized api calls.
        loginSuccess = (response.Cookies.Count > 0);
    }
    response.Close();
    //Now make a request to the api
    HttpWebRequest ApiRequest = (HttpWebRequest)System.Net.WebRequest.Create(string.Format("https://{0}/api/values", server));
    ApiRequest.CookieContainer = new CookieContainer();
    ApiRequest.CookieContainer.Add(response.Cookies[0]);
    //From here add code to get the response.
