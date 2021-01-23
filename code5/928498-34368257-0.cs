    Subject.ControllerContext = new ControllerContext(
        Mocked<HttpContextBase>().Object,
        new RouteData(),
        Subject);
    ViewEngines.Engines.Clear();
    ViewEngines.Engines.Add(Mocked<IViewEngine>().Object);
    Mocked<IViewEngine>()
        .Setup(x => x.FindPartialView(Subject.ControllerContext,
                                      It.IsAny<string>(), It.IsAny<bool>()))
        .Returns(new ViewEngineResult(Mocked<IView>().Object,
                                      Mocked<IViewEngine>().Object));
    Mocked<IView>()
        .Setup(x => x.Render(It.IsAny<ViewContext>(), It.IsAny<TextWriter>()))
        .Callback((ViewContext c, TextWriter w) => w.WriteLine("RENDERED"));
