    using System;
    using System.Collections.Generic;
    using System.Net;
    
    namespace Pokemon.BL.Utils
    {
        // http://codehelp.smartdev.eu/2009/05/08/improve-webclient-by-adding-useragent-and-cookies-to-your-requests/
        public class CGWebClient : WebClient
        {
            private System.Net.CookieContainer cookieContainer;
            private string userAgent;
            private int timeout;
    
            public System.Net.CookieContainer CookieContainer
            {
                get { return cookieContainer; }
                set { cookieContainer = value; }
            }
    
            public string UserAgent
            {
                get { return userAgent; }
                set { userAgent = value; }
            }
    
            public int Timeout
            {
                get { return timeout; }
                set { timeout = value; }
            }
    
            public CGWebClient()
            {
                timeout = -1;
                userAgent = "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0";
                cookieContainer = new CookieContainer();
            }
    
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
    
                if (request.GetType() == typeof(HttpWebRequest))
                {
                    ((HttpWebRequest)request).CookieContainer = cookieContainer;
                    ((HttpWebRequest)request).UserAgent = userAgent;
                    ((HttpWebRequest)request).Timeout = timeout;
                }
    
                return request;
            }
        }
    }
