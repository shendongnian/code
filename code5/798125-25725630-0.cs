    [Fact]
    public void CreatePartialView_ViewNameWithoutReplacementToken_ReturnsOriginalPath()
    {
        var engine = new TestableViewEngine();
        var view = (RazorView)engine.CreatePartialView("partial path", new ControllerContext());
        Assert.Equals("partial path", view.ViewPath);
    }
    [Fact]
    public void CreatePartialView_ViewNameWithReplacementToken_ReturnsViewWithTokenReplacedByControllerNamespace()
    {
        var engine = new TestableViewEngine();
        var controller = new DummyController();
        var controllerContext = new ControllerContext { Controller = controller };
        var view = (RazorView)engine.CreatePartialView("partial path %1", controllerContext);
        Assert.Equals("partial path Stub/Tests/Controllers", view.ViewPath);
    }
