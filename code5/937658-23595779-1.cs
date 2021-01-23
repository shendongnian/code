    // arrange
    var controller = new HomeController();
    var context = new Mock<HttpContextBase>();
    var session = new Mock<HttpSessionStateBase>();
    var user = new GenericPrincipal(new GenericIdentity("john"), new[] { "Contributor" });
    context.Setup(x => x.User).Returns(user);            
    context.Setup(x => x.Session).Returns(session.Object);
    var requestContext = new RequestContext(context.Object, new RouteData());
    controller.ControllerContext = new ControllerContext(requestContext, controller);
    // act
    var actual = controller.Index();
    // assert
    session.VerifySet(x => x["foo"] = "bar");
    ...
