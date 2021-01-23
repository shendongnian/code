    public static string HttpGet(string URI) 
    {
       System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
       req.Proxy = new System.Net.WebProxy(ProxyString, true);
       System.Net.WebResponse resp = req.GetResponse();
       System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
       return sr.ReadToEnd().Trim();
    }
