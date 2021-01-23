    [TestMethod]
    public void PreAuthorize_WithEmptyRequest_ReturnsNonNullResponse()
    {
        // Arrange
        var preAuthorizeRequest = new PreAuthorizeRequest();
    
        // Act
        var authorizeResponse = _dataProcessor.SendRequest(preAuthorizeRequest);
    
        // Assert
        Assert.IsNotNull(authorizeResponse);
    }
