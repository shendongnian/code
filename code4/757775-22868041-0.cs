        interface IWebServiceFactory
        {
            MyWebService client();
        }
    
        public class WebServiceFactory
        {
            public MyWebService client()
            {
                 return new MyWebService();
            }
        }
