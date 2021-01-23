    var client = new JsonServiceClient(gko_url);
    IWebProxy webProxy = new WebProxy("http://localhost:8888");
    client.Proxy = webProxy;
    var response = client.Post<Authenticate>("/auth", new Authenticate()
    {
        UserName = username,
        Password = password,
        RememberMe = true
    });
