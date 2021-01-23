    [Test]
    public void POST_PlaylistItem_Should_route_to_PlaylistItemController_Create_method()
    { 
        // setups
        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/PlaylistItem/");
        var config = new HttpConfiguration();
        // act
        WebApiConfig.Register(config);
        var route = Helpers.RouteRequest(config, request);
        // asserts
        route.Controller.Should().Be<PlaylistItemController>();
        route.Action.Should().Be("Create");
    }
    [Test]
    public void POST_CreateMultiple_PlaylistItem_Should_route_to_PlaylistItemController_CreateMultiple_method()
    {
        // setups
        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/PlaylistItem/CreateMultiple");
        var config = new HttpConfiguration();
        // act
        WebApiConfig.Register(config);
        var route = Helpers.RouteRequest(config, request);
        // asserts
        route.Controller.Should().Be<PlaylistItemController>();
        route.Action.Should().Be("CreateMultiple");
    }
