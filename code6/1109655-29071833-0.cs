    HttWebRequest CreateBaseRequest(Uri url)
    {
        var httpRequest = (HttpWebRequest)WebRequest.Create(url);
        httpRequest.Method = "POST";
        httpRequest.ContentType = "application/text";
        httpRequest.UseDefaultCredentials = true;
        return httpRequest;
    }
    void BuildRequestContent(HttpWebRequest httpRequest, Dictionary<string, string> values)
    {
        httpRequest.Timeout = this.connectionTimeoutInMilliseconds;
        this.AppendHeadersToRequest(httpRequest);
        // Build request content
        if (values != null && values.Count > 0)
        {
            var postData = new StringBuilder();
            foreach (var item in values)
            {
                postData.AppendFormat("&{0}={1}", item.Key, item.Value);
            }
            postData.Remove(0, 1);
            var data = Encoding.ASCII.GetBytes(postData.ToString());
            httpRequest.ContentLength = data.Length;
            using (var stream = httpRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        else
        {
            httpRequest.ContentLength = 0;
        }
        LoggingUtilities.Logger.TraceInformation("Created POST request to {0}", url);
    }
    public HttpWebRequest CreatePostRequest(Uri url, X509Certificate2 clientCertificate, Dictionary<string, string> values = null)
    {
        var httpRequest = CreateBaseRequest(url);
        httpRequest.ClientCertificates.Add(clientCertificate);
        BuildRequestContent(httpRequest, values);
        return httpRequest;
    }
    public HttpWebRequest CreatePostRequest(Uri url, string userToken, Dictionary<string, string> values = null)
    {
        var httpRequest = CreateBaseRequest(url);
        string authorizationToken = ADFSTokenHelper.SamlTokenBearerName + userToken;
        httpRequest.Headers.Add(ADFSTokenHelper.SamlAuthorizationHeaderName, authorizationToken);
        BuildRequestContent(httpRequest, values);
        return httpRequest;
    }
