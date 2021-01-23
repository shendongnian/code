    HtmlWeb hw = new HtmlWeb();
            hw.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
            hw.PreRequest = new HtmlAgilityPack.HtmlWeb.PreRequestHandler(p.ProxyOnPreRequest); // this is proxy request
            HtmlAgilityPack.HtmlDocument doc = hw.Load(openUrl);
    
        public bool ProxyOnPreRequest(HttpWebRequest request)
        {
            WebProxy myProxy = new WebProxy("203.189.134.17:80");
            request.Proxy = myProxy;
            return true; // ok, go on
        }
