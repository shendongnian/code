        public class MyAgent: WebAgent
        {
            public IWebProxy Proxy { get; set; }
            public override HttpWebRequest CreateRequest(string url, string method, bool prependDomain = true)
            {
                var base_request = base.CreateRequest(url, method, prependDomain);
                if (Proxy != null)
	            {
		            base_request.Proxy=Proxy;   
	            }
                return base_request;
            }
        }
