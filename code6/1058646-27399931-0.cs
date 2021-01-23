    public class LogerDataBaseTests
    {
        [TestCase]
        public void ValidateUserCalledWithGoodUserCredentialsRaisesLoginSuccesEventShouldPass()
        {
            var dataBaseConnectionMock = new Mock<Classes.DataBase.IDataBaseConncection>();
            dataBaseConnectionMock.Setup(m => m.getUserByCredentials(It.IsAny<string>(), It.IsAny<string>())).Returns(new object());
    
            var loger = new Classes.Loger.LogerDataBase(dataBaseConnectionMock.Object);
            bool successRaised = false;
            bool failureRaised = false;
            loginSucces += (s, e) => {successRaised = true;}
            loginFailed += (s, e) => {failureRaised = true;}
            loger.validateUser("user", "pass");
            
            Assert.IsTrue(successRaised);
            Assert.IsFalse(failureRaised);            
        }
    }
