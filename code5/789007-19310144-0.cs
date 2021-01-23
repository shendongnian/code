    public class MyWebServiceHelper
        {
            private string _url = null;
    
            public MyWebServiceHelper()
            {
                this._url = GetWsUrlFromDbOrAppConfig();
            }
    
            public CallWebService.MyWS GetMyWebServiceProxy()
            {
                return new CallWebService.MyWS("WcfBindingConfig", _url);
            }
        }
