    public class WebRequestState
        {
            public HttpWebRequest Request { get; set; }
            public object _object { get; set; }
    
    
    
            public WebRequestState(HttpWebRequest webRequest, object obj)
            {
                Request = webRequest;
                _object = obj;
            }
        }
