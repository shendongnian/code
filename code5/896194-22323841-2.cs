    [Test]
    public void Index_WhenNoTokenInSession_ReturnsDummyViewAndSetsToken()
    {
        // Arrange
        var queryString = new NameValueCollection { { "code", "dummyCodeValue" } };
        _mockSession.Setup(s => s["token"]).Returns(null);
        _mockRequest.Setup(r => r.QueryString).Returns(queryString);
        // Act
        ViewResult result = _homeController.Index() as ViewResult;
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("dummy", result.ViewName);
        _mockSession.VerifySet(s => s["token"] = "tokenValue", Times.Once);
    }
    [Test]
    public void Index_WhenTokenInSession_ReturnsDefaultView()
    {
        // Arrange
        _mockSession.Setup(s => s["token"]).Returns("foo");
        // Act
        ViewResult result = _homeController.Index() as ViewResult;
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(String.Empty, result.ViewName);
    }
