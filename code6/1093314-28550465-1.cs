    public class WebClientExtended : WebClient
    {
        #region Felder
        private CookieContainer container = new CookieContainer();
        #endregion
        #region Eigenschaften
        public CookieContainer CookieContainer
        {
            get { return container; }
            set { container = value; }
        }
        #endregion
        #region Konstruktoren
        public WebClientExtended()
        {
            this.container = new CookieContainer();
        }
        #endregion
        #region Methoden
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest r = base.GetWebRequest(address);
            var request = r as HttpWebRequest;
            request.AllowAutoRedirect = false; 
            request.ServicePoint.Expect100Continue = false;
            if (request != null)
            {
                request.CookieContainer = container;
            }
            ((HttpWebRequest)r).Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            ((HttpWebRequest)r).UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko"; //IE
            r.Headers.Set("Accept-Encoding", "gzip, deflate, sdch");
            r.Headers.Set("Accept-Language", "de-AT,de;q=0.8,en;q=0.6,en-US;q=0.4,fr;q=0.2");
            r.Headers.Add(System.Net.HttpRequestHeader.KeepAlive, "1");
            ((HttpWebRequest)r).AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return r;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            if (!string.IsNullOrEmpty(response.Headers["Location"]))
            {
                request = GetWebRequest(new Uri(response.Headers["Location"]));
                request.ContentLength = 0;
                response = GetWebResponse(request);
            }
            return response;
        }
        #endregion
    }
