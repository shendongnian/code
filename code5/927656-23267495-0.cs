    try
    {
        WebResponse response = GetWebResponse(url);
        responseBody = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(url);
        pageSource = httpClient.GetStringAsync(url).Result;
    }
    catch (WebException exception)
    {
        var response = (HttpWebResponse)exception.GetResponse();
        //the response is here..
    }
