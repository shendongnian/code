    [Test]
    public void UserIsValidForNotice_has_correct_expression()
    {
        var repoMock = new Mock<IUserRepository>();
        var sut = new EmailTasks(repoMock.Object);
        sut.UserIsValidForNotice(DateTime.Now);
        repoMock.Verify(r => r.FindAll(It.Is<Func<User, bool>>(func => func(someUser));
    }
