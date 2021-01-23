    [Test]
    public void GetAll_ShouldReturnAllFromFake()
    {
       // Arrrange
       var userService = new UserService(new FakeUserRepository())
       // Act
       var result = userService.GetAll();
       // Assert
       var user = result[0];
       Assert.AreEqual("Bob", user.FirstName);
       Assert.AreEqual("Smith", user.LastName);   
    }
