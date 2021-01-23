    [Test]
    public async Task ShouldRunNextMiddlewareOnceWhenNothingExists()
    {
        // ARRANGE
        int hitCount = 0;
        var server = TestServer.Create(app =>
        {
            app.UseHtml5Mode("test-resources", "/index.html");
            app.UseCountingMiddleware(() => { hitCount++; });
        });
    
        using (server)
        {
            // ACT
            await server.HttpClient.GetAsync(DoesNoExistHtmlPath);
    
            // ASSERT
            Assert.AreEqual(1, hitCount);
        }
    }
