    public class CookieAwareWebClient : WebClient
    {
        public string ResponseCookies { get; private set; }
        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            var response = base.GetWebResponse(request, result);
            this.ResponseCookies = response.Headers["Set-Cookie"];
            return response;
        }
    }
