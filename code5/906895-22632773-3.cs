     /// <summary>
    /// An HTTP based Client for sending request
    /// </summary>
    public class HTTPClient : WebClient, IClient
    {
        /// <inheritdoc/>
        /// <remarks>Modify the timeout of the web request</remarks>
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            request.Timeout = (int)new TimeSpan(0, 30, 0).TotalMilliseconds;
            return request;
        }
        /// <inheritdoc/>
        public string Request(string endPoint, string content)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml";
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                String response = client.UploadString(endPoint, "POST", content);
                return response;
            }
        }
    }
