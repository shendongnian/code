    public class WebClientEx : WebClient
    {
        public CookieContainer _cookies = new CookieContainer();
        public string Get(string URL)
        {
            string Result = "";
            int limit = 0;
            do
            {
                try
                {
                    Result = this.DownloadString(URL);
                    break;
                }
                catch(WebException w) //five tries
                {
                    Thread.Sleep(500);
                    limit++;
                    if (limit == 5)
                        return string.Empty; ;
                }
            } while (true);
            return Result;
        }
        public WebClientEx()
        {
            this.Encoding = Encoding.UTF8;
            System.Net.ServicePointManager.Expect100Continue = false;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.Host = "apps.db.ripe.net";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:24.0) Gecko/20100101 Firefox/24.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.KeepAlive = true;
            request.Proxy = new WebProxy();
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.CookieContainer = _cookies;
            request.Headers.Add("Accept-Language", "pl,en-us;q=0.7,en;q=0.3");
            request.ContentType = "application/x-www-form-urlencoded";
            return request;
        }
        public string Post(string URL, NameValueCollection data)
        {
            string Result = "";
            int limit = 0;
            do
            {
                try
                {
                    Result = Encoding.UTF8.GetString(this.UploadValues(URL, data));
                    break;
                }
                catch(WebException w)
                {
                    limit++;
                    if (limit == 5)
                        return string.Empty;
                }
            } while (true);
            return Result;
        }
    }
