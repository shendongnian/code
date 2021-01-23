    public static class MockHttpObjectBuilder
    {
        public static HttpContextBase GetMockHttpContext()
        {
            return GetMockHttpContext("~/");
        }
        public static HttpContextBase GetMockHttpContext(string url, string httpMethod = "GET")
        {
            var context = Substitute.For<HttpContextBase>();
            
            var req = GetMockHttpRequest(url, httpMethod);
            req.RequestContext.Returns(new RequestContext(context, new RouteData()));
            context.Request.Returns(req);
            var res = GetMockHttpResponse();
            context.Response.Returns(res);
            return context;
        }
        public static HttpRequestBase GetMockHttpRequest()
        {
            return GetMockHttpRequest("~/");
        }
        public static HttpRequestBase GetMockHttpRequest(string url, string httpMethod = "GET")
        {
            var req = Substitute.For<HttpRequestBase>();
            req.ApplicationPath.Returns("/");
            req.Headers.Returns(new NameValueCollection {{"X-Cluster-Client-Ip", "1.2.3.4"}});
            req.ServerVariables.Returns(new NameValueCollection());
            req.AppRelativeCurrentExecutionFilePath.Returns(url);
            req.HttpMethod.Returns(httpMethod);
            req.Url.Returns(new Uri("example.com/" + url.TrimStart('~')));
            return req;
        }
        public static HttpResponseBase GetMockHttpResponse()
        {
            var res = Substitute.For<HttpResponseBase>();
            res.ApplyAppPathModifier(Arg.Any<string>()).Returns(x => x[0]);
            return res;
        }
    }
