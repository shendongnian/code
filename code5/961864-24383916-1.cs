    [TestMethod]
    public void IndexMoq()
    {
        var identity = new GenericIdentity("tugberk");          
        var controller = new SutController();
        var controllerContext = new Mock<ControllerContext>();
        var principal = new Mock<IPrincipal>();
        principal.Setup(p => p.IsInRole("Administrator")).Returns(true);
        principal.SetupGet(x => x.Identity.Name).Returns("tugberk");
        controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
        controller.ControllerContext = controllerContext.Object;
        Assert.AreEqual(controller.Get(), identity.Name);
    }
