    ...
    string urlAddress = "http://www.google.com";
    string userName = "user01";
    string password = "puser01";
    string proxyServer = "127.0.0.1";
    int proxyPort = 8081;
    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(urlAddress);
    if (userName != string.Empty)
    {
        request.Proxy = new WebProxy(proxyServer, proxyPort)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(userName, password)
        };
        string basicAuthBase64 = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(string.Format("{0}:{1}", userName, password)));
        request.Headers.Add("Proxy-Authorization", string.Format("Basic {0}", basicAuthBase64));
    }
    using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
    {
        var stream = response.GetResponseStream();
        if (stream != null)
        {
            //--print the stream content to Console
            using (var reader = new StreamReader(stream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
    ...
