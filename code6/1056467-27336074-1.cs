    public string ReadPage(string path, string method = "GET"){
        var result = "";
        var request = (HttpWebRequest)WebRequest.Create(path);
        request.Method = method;            
        request.Host = "somehost.de";
        request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
        request.Referer = @"http://somehost.de/login.php?redir=list.php%3Ftype%3Dmm";
        request.AllowAutoRedirect = true;
        request.Headers.Add("Cookie", LoginCookie);
        try
        {
            var response = request.GetWEResponse();           
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            //throw;
        }
        return result;            
    }
