    Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
    Mock<HttpRequestBase> httpReguestMock = new Mock<HttpRequestBase>();
    httpContextMock.SetupGet(c => c.Request).Returns(httpReguestMock.Object);
    GenerationController controller = new GenerationController();
    controller.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), controller);
    controller.Index();
