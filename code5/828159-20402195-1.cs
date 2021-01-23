    [HttpPost]
    public async Task<HttpResponseMessage> SaveSomething(...)
    {
      SaveSomethingToDatabase(...);
      var image = await ThirdPartyToolAsync(someUrl);
      image.Save("someFullName");
    }
