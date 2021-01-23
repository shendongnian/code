    [TestMethod]
    [ExpectedException(typeof(System.Net.Http.HttpRequestException))]
    public async Task SomeTest()
    {
       await service.SearchAsync(searchOptions);
    }
