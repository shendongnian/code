     [Test]
     public void SomeTest()
     {
        var mockFactory = new Mock<IEntitiesFactory>();
        var mockEntities = new Mock<Entities>();
        var fakeUsers = new List<UserModel>
           {
              new UserModel
                 {
                    UserId = "Bob",
                    CPassword = "TheHashOfSecret"
                 }
           };
        mockEntities.SetupGet(_ => _.Users).Returns(fakeUsers.AsQueryable());
        mockFactory.Setup(_ => _.Create()).Returns(mockEntities.Object);
        var mockLog = new Mock<ILog>();
        var sut = new Authenticator(mockFactory.Object, mockLog.Object)
           {
              UserId = "Bob",
              Password = "Secret"
           };
        Assert.DoesNotThrow(() => sut.ValidateUser());
        Assert.IsNotNull(sut.User);
        mockLog.Verify(_ => _.LogLine(), Times.Once); ...
     }
