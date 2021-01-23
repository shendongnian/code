    public class OrderResult : IHttpActionResult
    {
        Order _order;
        HttpRequestMessage _request;
        public OrderResult(Order order, HttpRequestMessage request)
        {
            _order = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            
            var cookie = new CookieHeaderValue("session-id", "6789");
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return Task.FromResult(response);
        }
    }
