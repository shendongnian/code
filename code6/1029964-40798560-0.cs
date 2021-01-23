    public class HeaderParser
    {
        IDictionary<string, object>  _requestContext;
        IDictionary<string, string[]> _headers;
        public HeaderParser(IDictionary<string, object> requestContext)
        {
            _requestContext = requestContext;
            _headers = requestContext["owin.RequestHeaders"] as IDictionary<string, string[]>;
        }
        public string GetEmployeeNoFromHeader()
        {
            if (_headers != null && _headers.ContainsKey("X-EmployeeNo") && _headers["X-EmployeeNo"] != null && _headers["X-EmployeeNo"].Length > 0)
            {
                return _headers["X-EmployeeNo"][0];
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent("EMPLOYEE NO NOT AVAILABLE IN REQUEST");
                throw new HttpResponseException(response);
            }
        }
    }
