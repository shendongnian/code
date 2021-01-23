    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();
        public override object this[string name]
        {
            get { return m_SessionStorage[name]; }
            set { m_SessionStorage[name] = value; }
        }
        
        public override void Abandon()
        {
            // Do nothing
        }
    }
    public class MockHelpers
    {
        public static HttpContext FakeHttpContext()
        {
            var httpRequest = new HttpRequest("", "http://localhost/", "");
            var stringWriter = new StringWriter();
            var httpResponse = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponse);
            var sessionContainer = new HttpSessionStateContainer(
                "id", 
                new SessionStateItemCollection(),
                new HttpStaticObjectsCollection(), 
                10, 
                true,
                HttpCookieMode.AutoDetect,
                SessionStateMode.InProc, 
                false);
            SessionStateUtility.AddHttpSessionStateToContext(httpContext, sessionContainer);
            return httpContext;
        }
    }
