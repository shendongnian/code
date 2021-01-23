    public class TestHttpActionResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly string _responseString;
        public TestHttpActionResult(HttpRequestMessage request, string responseString)
        {
            _request = request;
            _responseString = responseString;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.Created);
            response.Content = new StringContent(_responseString);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            return Task.FromResult(response);
        }
    }
