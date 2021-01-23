    [Fact]
    public void ShouldMockContextUser()
    {
      // arrange
      var controller = new HomeController();
      var user = Substitute.For<IPrincipal>();
      user.Identity.Returns(Substitute.For<ClaimsIdentity>());
      user.Identity.As<ClaimsIdentity>()
          .FindFirst(ClaimTypes.NameIdentifier)
          .Returns(new Claim(ClaimTypes.NameIdentifier, "John"));
      // act
      controller.ControllerContext.RequestContext.Principal = user;
      // assert
      controller.User.Should().BeSameAs(user);
      controller.User.Identity.GetUserId().Should().Be("John");
    }
