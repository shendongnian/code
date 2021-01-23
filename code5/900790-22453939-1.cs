    // create request
    var request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
    request.Credentials = new NetworkCredential("Username", "Password");
    
    try
    {
        // get response
        var response = (HttpWebResponse)request.GetResponse();
        var statusCode = response.StatusCode;
    
        // verify response
        if (statusCode == HttpStatusCode.OK)
        {
            // login was ok
        }
    }
    catch (WebException ex)
    {
        if (((HttpWebResponse) ex.Response).StatusCode == HttpStatusCode.Unauthorized)
        {
            // unauthorized
        }
    }
