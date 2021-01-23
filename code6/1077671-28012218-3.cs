      // arrange
      Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
      httpContext.SetupGet(c => c.User.Identity.Name).Returns("John Doe");
      Mock<ControllerBase> baseControler = new Mock<ControllerBase>();
      this.controller.ControllerContext =
        new ControllerContext(httpContext.Object, new RouteData(), baseControler.Object);
      // act
      var result = this.controller.Index();
      // assert
      Assert.AreEqual("John Doe", ((ViewResult)result).ViewBag.UserName);
