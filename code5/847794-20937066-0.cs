    [TestInitialize, SetUp]
    public void TestInitilize()
    {
        var mockedUserReop = MockRepository.GenerateMock<IUserRepository >();
        UserService = new UserService(mockedUserReop );
    }
