    public string ReadPage(string path, string method = "GET")
    {
        var request = (HttpWebRequest)WebRequest.Create(path);
        request.Method = method;            
        request.Host = "somehost.de";
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
        request.Referer = @"http://somehost.de/login.php?redir=list.php%3Ftype%3Dmm";
        request.AllowAutoRedirect = true;
        request.Headers.Add("Cookie", LoginCookie);
        using (WebResponse response = request.GetWEResponse())
        using (var sr = new StreamReader(response.GetResponseStream()))
        {
            return sr.ReadToEnd();
        }
    }
