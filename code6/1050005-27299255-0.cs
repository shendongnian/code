    HttpContextBase GetContext(string userName) 
    {
        var user = new GenericPrincipal(new GenericIdentity(userName, "Forms"), new string[] {});
        
        var contextMock = new Mock<HttpContextBase>();
        contextMock.Setup(context => context.User).Returns(user);
        contextMock.Setup.....
        return contextMock.Object;
    }
