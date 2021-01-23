    [HttpPost]
    public async Task<HttpResponseMessage> SaveSomething(...)
    {
      SaveSomethingToDatabase(...);
      var image = await Task.Run(() => ThirdPartyTool(someUrl));
      image.Save("someFullName");
    }
