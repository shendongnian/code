    public class WebClient : MarshalByRefObject, IWebClient
    {
        public WebClientResponse GetResponse(string address)
        {
            return GetResponse(address, null);
        }
        public WebClientResponse GetResponse(string address, string securityProtocol)
        {
            if (!string.IsNullOrWhiteSpace(securityProtocol))
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)Enum.Parse(typeof(SecurityProtocolType), securityProtocol);
            var response = new WebClientResponse();
            try
            {
                using (var wc = new System.Net.WebClient())
                {
                  // <do stuff>
                }
            }
            catch (Exception ex)
            {
                response.Exception = new GetResponseException(string.Format("Unable to get response from {0}", address), ex);
            }
            return response;
        }
    }
    [Serializable]
    public class WebClientResponse
    {
        public Exception Exception { get; set; }
        public string Response { get; set; }
    }
     [Serializable]
    public class GetResponseException : Exception
    {
        public GetResponseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public GetResponseException(SerializationInfo info, StreamingContext context)  : base(info, context)
        {
        }
    }
