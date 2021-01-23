    AppHost.Simulate("MyMvcApp").Start(browsingSession =>
    {
        var loginResult = browsingSession.Post("Users/Login/", 
                                               new { UserName = "aaa", Password = "bbb" });
        Assert.That(loginResult.Response.StatusCode, Is.EqualTo(200));
    
        var result = browsingSession.Post("Money/Create/", 
                                          new { Amount = "1,000,000" });
        Assert.That(result.Response.StatusCode, Is.EqualTo(200));
    });
