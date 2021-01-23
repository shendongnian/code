    class MyProxy : IWebProxy
    {
        private readonly Uri _proxyUri;
        public MyProxy(Uri proxyUri)
        {
            _proxyUri = proxyUri;
        }
    
        public ICredentials Credentials { get; set; }
        public Uri GetProxy(Uri destination)
        {
            return _proxyUri;
        }
        public bool IsBypassed(Uri destination)
        {
            return false;
        }
    }
