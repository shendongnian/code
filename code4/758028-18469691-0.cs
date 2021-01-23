    var request = (HttpWebRequest)WebRequest.Create(url);
    
    request.Method = verb;
    request.Timeout = timeout;
    request.Proxy = null;
    request.KeepAlive = false;
    request.Headers.Add("Content-Encoding", "UTF-8");
    System.Net.ServicePointManager.Expect100Continue = false;
    request.ServicePoint.Expect100Continue = false;
    
    if ((verb == "POST" || verb == "PUT") && !String.IsNullOrEmpty(data))
    {
        var dataBytes = Encoding.UTF8.GetBytes(data);
    
        using (var dataStream = request.GetRequestStream())
        {
            dataStream.Write(dataBytes, 0, dataBytes.Length);
        }
    }
    
    string responseStr;
    using (var response = request.GetResponse())
    {
        using (var responseReader = new StreamReader(rStream, Encoding.UTF8))
        {
            responseStr = responseReader.ReadToEnd();
        }
    }
