    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("yourUrl");
    request.Method = "DELETE";
            
    request.Headers.Add("Content-type", "application/json");
    request.Headers.Add("Accept", "application/json");
    request.ContentType = "application/json";
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
