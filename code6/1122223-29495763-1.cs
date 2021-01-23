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
    
            // Make call to get data or do something as authenticated user
            var dataYouWant = client.DownloadString("myURL/page_with_data");
        }
    }
    
    public class CookieAwareWebClient : WebClient
    {
        private const string COOKIEKEY = ".ASPXAUTH";
        public string AspAuthCookieValue { get; set; }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest) base.GetWebRequest(address);
    
            if (!string.IsNullOrEmpty(AspAuthCookieValue))
            {
                request.CookieContainer.Add(new Cookie
                (
                    COOKIEKEY,
                    AspAuthCookieValue
                ));
            }
    
            return request;
        }
    
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var response = (HttpWebResponse) base.GetWebResponse(request);
            var authCookie = response.Cookies[COOKIEKEY];
    
            if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
            {
                AspAuthCookieValue = authCookie.Value;
            }
    
            return response;
        }
    }
