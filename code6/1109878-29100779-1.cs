    var server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
    var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
    var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
    var session = new MockHttpSession();
    var context = new Mock<HttpContextBase>();
    context.SetupGet(x => x.Request).Returns(request.Object);
    context.SetupGet(x => x.Response).Returns(response.Object);
    context.SetupGet(x => x.Server).Returns(server.Object);
    context.SetupGet(x => x.Session).Returns(session);
    HttpContext.Current = MockHelpers.FakeHttpContext();
            
    var controller = new LoginController();
    controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
    JsonResult result = controller.LoginUser(new LoginHelper { userName = "MyUserName", password = ""InvalidPassword }) as JsonResult;
