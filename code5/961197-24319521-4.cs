    private Mock<ControllerContext> GetContextBase()
    {
        var fakeHttpContext = new Mock<HttpContextBase>();
        var request = new Mock<HttpRequestBase>();
        var response = new Mock<HttpResponseBase>();
        var session = new MockHttpSession();
        var server = new MockServer();
        var parms = new RequestParams();
        var uri = new Uri("http://TestURL/Home/Index");
        var fakeIdentity = new GenericIdentity("DOMAIN\\username");
        var principal = new GenericPrincipal(fakeIdentity, null);
        request.Setup(t => t.Params).Returns(parms);
        request.Setup(t => t.Url).Returns(uri);
        fakeHttpContext.Setup(t => t.User).Returns(principal);
        fakeHttpContext.Setup(ctx => ctx.Request).Returns(request.Object);
        fakeHttpContext.Setup(ctx => ctx.Response).Returns(response.Object);
        fakeHttpContext.Setup(ctx => ctx.Session).Returns(session);
        fakeHttpContext.Setup(ctx => ctx.Server).Returns(server);
        var controllerContext = new Mock<ControllerContext>();
        controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);
        return controllerContext;
    }
