    // Do any setup work
    HttpConfiguration config = new HttpConfiguration();
    config.Routes.MapHttpRoute("Default", "{controller}/{action}");
    // Setup in memory server and client
    HttpServer server = new HttpServer(config);
    HttpClient client = new HttpClient(server);
    // Act
    HttpResponseMessage response = client.GetAsync("http://localhost/" + requestUrl).Result;
    // Assert
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    Assert.Equal(count, response.Content.ReadAsAsync<int>().Result);
