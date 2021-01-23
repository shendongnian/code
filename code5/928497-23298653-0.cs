    var mock = new Mock<ControllerContext>();
    mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
    if (userName != null)
    {
       mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
       mock.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(true);
    }
    else
    {
       mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(false);
    }
    var routeData = new RouteData();
    routeData.Values.Add("controller", "BlogController");
    mock.SetupGet(m => m.RouteData).Returns(routeData);
    var view = new Mock<IView>();
    var engine = new Mock<IViewEngine>();
    var viewEngineResult = new ViewEngineResult(view.Object, engine.Object);
    engine.Setup(e => e.FindPartialView(It.IsAny<ControllerContext>(), It.IsAny<string>(), It.IsAny<bool>())).Returns(viewEngineResult);
    ViewEngines.Engines.Clear();
    ViewEngines.Engines.Add(engine.Object);
    var controller = new BlogController();
    controller.ControllerContext = mock.Object;
