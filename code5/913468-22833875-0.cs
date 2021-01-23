    [Theory]
    [InlineData("manager", "manager")]
    public void LoginTest(string userId, string password)
    {
        // Arrange
        // System under test
        IUserManagementService userService = new UserManagementService();
        var request = new LoginRequest().Prepare();
        request.UserId = userId;
        request.Password = password;
        var expectedResponse = new LoginResponse(request.RequestId);
        //Act
        var actualResponse = userService.Login(request);
        //Assert
        Assert.AreEqual(actualResponse.Something, expectedResponse.Something);            
    }
