    var httpRequest = new Mock<HttpRequestBase>();
    var stream = new MemoryStream(Encoding.Default.GetBytes("Hello world"));
    httpRequest.Setup(r => r.InputStream).Returns(stream);
    var httpContext = new Mock<HttpContextBase>();
    httpContext.Setup(c => c.Request).Returns(httpRequest.Object);
    var controller = new HomeController();
    var routeData = new RouteData();
    controller.ControllerContext = 
         new ControllerContext(httpContext.Object, routeData, controller);
    var result = (JsonResult)controller.GetZZ();
    Assert.That(result.Data, Is.EqualTo(42)); // your assertions here
