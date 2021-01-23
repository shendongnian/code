    [Fact]
    public void ShouldMockContextUser()
    {
      // arrange
      var controller = new HomeController();
      var user = Substitute.For<IPrincipal>();
      // act
      controller.ControllerContext.RequestContext.Principal = user;
      // assert
      controller.User.Should().BeSameAs(user);
    }
