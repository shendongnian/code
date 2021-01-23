    public void Run() {
        string url = "http://example.com/api";
        string contentType = "application/xml";
        string postData = "<this><is><my>xml</my></is></this>";
        string responseBody = PostRequest(url, contentType, postData);
    }
    public string PostRequest(string url, string contentType, string postData) 
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.Timeout = 30000;
            request.ReadWriteTimeout = 30000;
            Log.Debug("HTTP request: [" + request.Method + "] " + url);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            var response = (HttpWebResponse) request.GetResponse();
            Log.Debug("HTTP response: " + response.StatusCode + " - " + response.StatusDescription);
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseBody = reader.ReadToEnd();
            response.Close();
                
            return responseBody;
        }
        catch (Exception e)
        {
            Log.Error("Exception while running HTTP request.", e);
            throw e;
        }
    }
