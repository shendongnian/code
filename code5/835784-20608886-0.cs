    var principalMock = new Mock<IPrincipal>();
    var identityMock = new Mock<IIdentity>();
    identityMock.Setup(x => x.Name).Returns("Test!");
    identityMock.Setup(x => x.IsAuthenticated).Returns(true); // optional ;)
    userMock.Setup(x => x.Identity).Returns(identityMock.Object);
    var httpReqBase = new Mock<HttpRequestBase>(); // this is useful if you want to test Ajax request checks or cookies in the controller.
    var httpContextBase = new Mock<HttpContextBase>();
    
    httpContextBase.Setup(x => x.User).Returns(userMock.Object);
    httpContextBase.Setup(x => x.Session[It.IsAny<string>()]).Returns(1); //Here is the session indexer. You can swap 'any' string for specific string.
    httpContextBase.Setup(x => x.Request).Returns(httpReqBase.Object);
