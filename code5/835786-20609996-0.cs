    [TestClass]
    public class SutTest
    {
        [TestMethod]
        public void GetCartId_WhenUserNameIsNotNull_SessionContainsUserName()
        {
            var httpContextStub = new Mock<HttpContextBase>();
            var httpSessionStub = new Mock<ISessionSettings>();
            httpSessionStub.Setup(x => x.Get<string>(It.IsAny<string>())).Returns(() => null);
            httpSessionStub.SetupSequence(x => x.Get<string>(It.IsAny<string>()))
                .Returns(null)
                .Returns("FakeName");
            var httpUserStub = new Mock<IPrincipal>();
            var httpIdenttyStub = new Mock<IIdentity>();
            httpUserStub.SetupGet(x => x.Identity).Returns(httpIdenttyStub.Object);
            httpIdenttyStub.SetupGet(x => x.Name).Returns("FakeName");
            httpContextStub.Setup(x => x.User).Returns(httpUserStub.Object);
            var sut = new Sut(httpSessionStub.Object);
            var result = sut.GetCartId(httpContextStub.Object);
            Assert.AreEqual("FakeName",result );
        }
    }
