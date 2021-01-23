    public class GetSomeOData
    {
        private const string COOKIEKEY = ".ASPXAUTH";
        private string _cookieValue;
    
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
    
            using (var client = new CookieAwareWebClient())
            {
                var values = new NameValueCollection
                {
                    {"username", "admin"},
                    {"password", "admin"},
                };
    
                // Make call to authenticate
                client.UploadValues("myURL/j_security_check", values);
    
                _cookieValue = client.AspAuthCookieValue;
    
                // Make call to get data or do something as authenticated user
                var dataYouWant = GetOData();
            }
        }
    
        public dynamic GetOData()
        {
            var feed = new ODataFeed("http://www.your-odata-url.com");
            feed.BeforeRequest += AddCookieToRequest;
            var db = Database.Opener.Open(feed);
    
            return db.SomeData.FindById(1234);
        }
    
        public void AddCookieToRequest(HttpRequestMessage request)
        {
            request.Headers.Add("Cookie", String.Format("{0}={1}", COOKIEKEY, _cookieValue));
        }
    
        public class CookieAwareWebClient : WebClient
        {
            public string AspAuthCookieValue { get; set; }
    
            protected override WebResponse GetWebResponse(WebRequest request)
            {
                var response = (HttpWebResponse)base.GetWebResponse(request);
                var authCookie = response.Cookies[COOKIEKEY];
    
                if (authCookie != null && !String.IsNullOrEmpty(authCookie.Value))
                {
                    AspAuthCookieValue = authCookie.Value;
                }
    
                return response;
            }
        }
    }
