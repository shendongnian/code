    void DownloadUrl()
    {
        HttpWebRequest requestHttp = (HttpWebRequest)HttpWebRequest.CreateHttp(new Uri(serverUrl, UriKind.Absolute));
        requestHttp.BeginGetRequestStream(SendRequestContent, requestHttp);
    }
    void SendRequestContent(IAsyncResult Result)
    {
        string RString = string.Format("rftoken=123456789");
        HttpWebRequest req = (HttpWebRequest)Result.AsyncState;
        var reqStream = req.EndGetRequestStream(Result);
        using(StreamWriter writer = new StreamWriter(reqStream))
            writer.Write(RString);
        //And here you have again GetRequestStream, I suppose it's wrong and you want ResponseStream, you cannot instantiate twice the request stream...
        req.BeginGetResponse(GetResponse, req);
    }
    void GetResponse(IAsyncResult Result)
    {
        var req = (HttpWebRequest)Result.AsyncState;
        var response = (HttpWebResponse)req.EndGetResponse(Result);
        
        string content = null;
        using(StreamWriter sw = new StreamWriter(response.GetResponseStream())
            content = sw.ReadToEnd();
        //And now you have the HTTP response in the "content" string, you can now finally use it. Beware you are outside the UI thread, if you must interact with it remember to use Invoke()
    }
