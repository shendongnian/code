    public bool SendPushNotification(string jsonContent)
    {
        string urlpath = "https://api.parse.com/1/push";
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(urlpath);
        request.Method = "POST";
        string appId = "...";
        string restApiKey = "...";
        request.Headers.Add("X-Parse-Application-Id", appId);
        request.Headers.Add("X-Parse-REST-API-KEY", restApiKey);
        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        Byte[] byteArray = encoding.GetBytes(jsonContent);
        request.ContentLength = byteArray.Length;
        request.ContentType = @"application/json";
        using (Stream dataStream = request.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }
        
        try
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                long length = response.ContentLength;
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    JObject jObjRes = JObject.Parse(responseText);
                    if (Convert.ToString(jObjRes).IndexOf("true") != -1)
                    {
                        return true;
                    }
                }
            }
        }
        catch (WebException ex)
        {
            // Log exception and throw as for GET example above
            return false;
        }
        return false;
    }
