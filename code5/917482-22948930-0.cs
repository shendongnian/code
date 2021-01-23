    [TestMethod]
    public void Index()
    {
        HomeController controller = new HomeController();
        ViewResult result = controller.Index() as ViewResult;
        Assert.IsNotNull( result.Model );
    }
