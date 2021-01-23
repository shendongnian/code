    public class HttpContextHelper
    {
        public static HttpContext CreateHttpContext(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            // http://stackoverflow.com/questions/9624242/setting-the-httpcontext-current-session-in-unit-test
            var httpContext = new HttpContext(httpRequest, httpResponse);
            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                    new HttpStaticObjectsCollection(), 10, true,
                                                    HttpCookieMode.AutoDetect,
                                                    SessionStateMode.InProc, false);
            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                        BindingFlags.NonPublic | BindingFlags.Instance,
                                        null, CallingConventions.Standard,
                                        new[] { typeof(HttpSessionStateContainer) },
                                        null)
                                .Invoke(new object[] { sessionContainer });
            return httpContext;
        }
        public class FakeHttpRequest : HttpRequestBase
        {
            private string applicationPath;
            public FakeHttpRequest(string applicationPath)
            {
                this.applicationPath = applicationPath;
            }
            public override string ApplicationPath
            {
                get
                {
                    return this.applicationPath;
                }
            }
        }
        public class FakeHttpContext : HttpContextBase
        {
            private HttpRequestBase request;
            private HttpResponseBase response;
            public FakeHttpContext(HttpRequestBase request, HttpResponseBase response)
                : base()
            {
                this.request = request;
                this.response = response;
            }
            public override HttpRequestBase Request
            {
                get
                {
                    return this.request;
                }
            }
            public override HttpResponseBase Response
            {
                get
                {
                    return this.response;
                }
            }
        }
    }
