    [SetUp]
    public void Setup()
    {
        _userService = new UserService(It.IsAny<IUserRepository>());
    }
    [Test]
    public void RegisterUserWithItIsAny()
    {
        bool result = _userService.RegisterUser("abc");
        Assert.True(result);
    }
    [Test]
    public void RegisterUserWithMockOf()
    {
        bool result = _userService.RegisterUser("abc");
        Assert.True(result);
    }
