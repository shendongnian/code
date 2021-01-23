    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.your.url");
    request.Method = "DELETE";
    request.ContentType = "application/json";
    request.Accept = "application/json";
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
        string json = "{\"key\":\"value\"}";
        streamWriter.Write(json);
        streamWriter.Flush();
    }
    using (var httpResponse = (HttpWebResponse)request.GetResponse())
    {
        // do something with response
    }
