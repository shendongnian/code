    [TestInitialize]
    public void Initialize()
    {
        _unitOfWork = A.Fake<IUnitOfWork>();
        A.CallTo(() => _unitOfWork.GetUserById(userID))
            .Returns(new User
            {
                UserID = userID,
                RegistrationDate = DateTime.Now,
            });
    }
    
    [TestMethod]
    public void GetUserByID()
    {
        var userService = new UserService(_unitOfWork);
        var user = userService.GetUserById(userID);
        Assert.IsInstanceOfType(user, typeof(Domain.User));
        Assert.AreEqual(userID, user.userID);
    }
