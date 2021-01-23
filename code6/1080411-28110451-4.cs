      // arrange
      var userService = Substitute.For<IUserService>();
      var controller = new FavoritesController(userService);
      var favorites = new[] { "fav1", "fav2" };
      userService.IsAuthorized("John").Returns(true);
      userService.GetFavorites("John").Returns(favorites);
      controller.User = Substitute.For<IPrincipal>();
      controller.User.Identity.Name.Returns("John");
      // act
      var result = controller.GetFavorites();
      // assert
      result.Should().BeOfType<OkNegotiatedContentResult<string[]>>();
      ((OkNegotiatedContentResult<string[]>)result).Content.Should().BeSameAs(favorites);
