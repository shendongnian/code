    public class ActionResponse : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;
        HttpStatusCode _statusCode;
    
        public ActionResponse(string value, HttpStatusCode statusCode, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
            _statusCode = statusCode;
        }
    
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage() {
                Content = new StringContent(_value),
                ReasonPhrase = _value,
                StatusCode = _statusCode,
                RequestMessage = _request,
            };
    
            //Performed some logging logic here by checking some business rules(it all depends on the requirement)
    
            response.Headers.Add("ResponseMessage", _value);
            return Task.FromResult(response);
        }
    }
