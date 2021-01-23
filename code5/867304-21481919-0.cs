    // Not sure if you have this mock already, this is the "client" variable
    // in your Use method action
    Mock<IAuthentication> mockAuthentication = mockRepository.Create<IAuthentication>();
    AuthenticationProxyService.Setup(a => a.Use(It.IsAny<Action<IAuthentication>>()))
                              .Callback<Action<IAuthentication>>(a => a(mockAuthentication.Object));
