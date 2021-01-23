     class MyWebClient : WebClient
    {
        Uri _responseUri;
        public CookieContainer CookieContainer;
        public Uri ResponseUri
        {
            get { return _responseUri; }
        }
        public MyWebClient()
        {
            CookieContainer = new CookieContainer(); //TODO improve with read/write actions from disk. (binaryformatter)
        }
        public string GetCookieValue(string name)
        {
            return CookieContainer.GetCookies(_responseUri).Cast<Cookie>().First(c => c.Name == name).Value;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            var webRequest = request as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.CookieContainer = CookieContainer;
            }
            return request;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            _responseUri = response?.ResponseUri;
            return response;
        }
    }
