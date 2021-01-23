    public partial class MyService
    {
        private ConcurrentDictionary<string, string> requestHeaders = new ConcurrentDictionary<string, string>();
        public void SetRequestHeader(string headerName, string headerValue)
        {
            this.requestHeaders.AddOrUpdate(headerName, headerValue, (key, oldValue) => headerValue);
        }
        protected override WebRequest GetWebRequest(Uri uri)
        {
            var request = base.GetWebRequest(uri);
            var httpRequest = request as HttpWebRequest;
            if (httpRequest != null)
            {
                foreach (string headerName in this.requestHeaders.Keys)
                {
                    httpRequest.Headers[headerName] = this.requestHeaders[headerName];
                }
            }
            return request;
        }
    }
