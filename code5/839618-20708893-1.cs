    [Fact]
    public void Get_Root_Should_Return_Page_With_Meta_Description()
    {
        // Given
        var browser = new Browser(x => x.Module<TestModule>());
    
        // When
        var result = browser.Get("/description");
    
        // Then
        result.Body["meta[name=description]"].ShouldExistOnce();
    }
