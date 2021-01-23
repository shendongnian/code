    [TestMethod]
    public void TestMethod1()
        {
            //Arrange
            var userList = new List<User>();
            userList .Add(new User { Name="Mike", Active = false });
            userList .Add(new User { Name="Mary", Active = true });
            var stubRepo = new StubRepo{ PersonList = userList});
            var emailSender = Mock<IEmailSender>();
             var emailTask = new EmailTask(stubRepo);
            emailTask.EmailSender = emailSender.Object;
            //Action
            emailTask.SendNoticeEmail(.....);
            //Assert - Verify email only sent to the one active user
            emailSender.Verify(x => x.SendEmail(It.IsAny<User>()), Times.Once())
        }
