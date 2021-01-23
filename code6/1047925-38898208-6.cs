    [Test]
    public async Task ShouldRunNextMiddlewareOnceWhenNothingExists()
    {
        // ARRANGE
        int hitCount = 0;
        var server = TestServer.Create(app =>
        {
            app.UseHtml5Mode("test-resources", "/does-not-exist.html");
            app.UseCountingMiddleware(() => { hitCount++; });
        });
    
        using (server)
        {
            // ACT
            await server.HttpClient.GetAsync("/does-not-exist.html");
    
            // ASSERT
            Assert.AreEqual(1, hitCount);
        }
    }
