    [Fact]
    public void GetReturnsResponseWithCorrectStatusCode()
    {
        var baseAddress = new Uri("http://localhost:8765");
        var config = new HttpSelfHostConfiguration(baseAddress);
        config.Routes.MapHttpRoute(
            name: "API Default",
            routeTemplate: "{controller}/{id}",
            defaults: new
            {
                controller = "Home",
                id = RouteParameter.Optional
            });
        var server = new HttpSelfHostServer(config);
        using (var client = new HttpClient(server))
        {
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    new SimpleWebToken(new Claim("userName", "foo")).ToString());
    
            var response = client.GetAsync("").Result;
    
            Assert.True(
                response.IsSuccessStatusCode,
                "Actual status code: " + response.StatusCode);
        }
    }
