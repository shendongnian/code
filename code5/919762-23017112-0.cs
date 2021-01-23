    public string GetJsonResult(string url, string queryStringValues)
    {
    // Create web request
    HttpWebRequest httpWebRequest;
    httpWebRequest = (HttpWebRequest)WebRequest.Create(url + queryStringValues);
    httpWebRequest.Method = "POST";
    httpWebRequest.Timeout = 6000;
    httpWebRequest.ContentType = "application/json";
    System.Net.ServicePointManager.Expect100Continue = false;
    // Make the request and get the response
    HttpWebResponse response = null;
    response = (HttpWebResponse)httpWebRequest.GetResponse();
    string content = "";
    using (var stream = new StreamReader(response.GetResponseStream()))
    {
    content = stream.ReadToEnd();
    }
    return content;
    }
