    [TestClass]
    public class LogerDataTest
    {
        [TestMethod]
        public void validateUser_getUserByCredentialsReturnsNotNull_loginSuccesEventIsRaised()
        {
            // Arrange
            const int loginSuccesExpected = 1;
            int loginSuccesActual = 0;
            Mock<DataBase.IDataBaseConncection> dataConnectionStub = new Mock<DataBase.IDataBaseConncection>();
            dataConnectionStub.Setup(db => db.getUserByCredentials("loginFake", "passwordFake")).Returns("User");
            LogerDataBase logerData = new LogerDataBase(dataConnectionStub.Object);
            logerData.loginSucces += (sender, args) =>
            {
                loginSuccesActual++;
            };
    
            // Act
            logerData.validateUser("loginFake", "passwordFake");
    
            // Assert
            Assert.AreEqual(loginSuccesExpected, loginSuccesActual);
        }
    
        [TestMethod]
        public void validateUser_getUserByCredentialsReturnsNull_loginFailedEventIsRaised()
        {
            // Arrange
            const int loginFailedExpected = 1;
            int loginFailedActual = 0;
            Mock<DataBase.IDataBaseConncection> dataConnectionStub = new Mock<DataBase.IDataBaseConncection>();
            dataConnectionStub.Setup(db => db.getUserByCredentials("loginFake", "passwordFake")).Returns(null);
            LogerDataBase logerData = new LogerDataBase(dataConnectionStub.Object);
            logerData.loginFailed += (sender, args) =>
            {
                loginFailedActual++;
            };
    
            // Act
            logerData.validateUser("loginFake", "passwordFake");
    
            // Assert
            Assert.AreEqual(loginFailedExpected, loginFailedActual);
        }	
    }
