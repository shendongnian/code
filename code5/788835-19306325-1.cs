    public SomeController CreateControllerForUser(string userName) 
    {
        var mock = new Mock<ControllerContext>();
        mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
        mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
        var controller = new SomeController();
        controller.ControllerContext = mock.Object;
        return controller;
    }
