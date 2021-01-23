    [Test]
    public void IsAdmin_CalledByAdmin_ReturnTrue()
    {
        UserService userService = new UserService();
        var principalMock = new Mock<IPrincipal>();
        principalMock.Setup(x => x.IsInRole("admin")).Returns(true);
        var requestMock = new Mock<IRequest>();
        requestMock.Setup(x => x.User).Returns(principalMock.Object);
        var result = userService.IsAdmin(new HubCallerContext(requestMock.Object, ""));
        Assert.IsTrue( result, "Something is wrong." );
    }
    [Test]
    public void IsAdmin_CalledByUser_ReturnFalse()
    {
        UserService userService = new UserService();
        var principalMock = new Mock<IPrincipal>();
        principalMock.Setup(x => x.IsInRole("admin")).Returns(false);
        var requestMock = new Mock<IRequest>();
        requestMock.Setup(x => x.User).Returns(principalMock.Object);
        var result = userService.IsAdmin(new HubCallerContext(requestMock.Object, ""));
        Assert.IsFalse( result, "Something is wrong." );
    }
