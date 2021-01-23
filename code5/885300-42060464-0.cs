    public HttpWebRequest CreateWebRequest()
            {
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("url"); 
    IWebProxy proxy = request.Proxy;
                if (proxy != null)
                {
                    string proxyuri = proxy.GetProxy(request.RequestUri).ToString();
                    request.UseDefaultCredentials = true;
                    request.Proxy = new WebProxy(proxyuri, false);
                    request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
     return request;
     }
