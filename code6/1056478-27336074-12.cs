    public string ReadPage(string path, string method = "GET")
    {
        var request = (HttpWebRequest)WebRequest.Create(path);
        request.Method = method;            
        request.Host = "somehost.de";
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
        request.Referer = @"http://somehost.de/login.php?redir=list.php%3Ftype%3Dmm";
        request.AllowAutoRedirect = true;
        request.Headers.Add("Cookie", LoginCookie);
        using (var response = (HttpWebResponse)request.GetWEResponse())
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            return reader.ReadToEnd();
        }
    }
