    [TestMethod]
    public void TestMethod1()
    {
      HomeController homeController = new HomeController();
      ActionResult result = homeController.Index(10);
      Assert.IsInstanceOfType(result,typeof(RedirectToRouteResult));
      RedirectToRouteResult routeResult = result as RedirectToRouteResult;
      Assert.AreEqual(routeResult.RouteValues["action"], "asd");
    }
    
    [TestMethod]
    public void TestMethod2()
    {
      HomeController homeController = new HomeController();
      ActionResult result = homeController.Index(1);
      Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
