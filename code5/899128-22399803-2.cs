    antiForgeryMock.Setup(m => m.Validate(
            It.IsAny<string>(),
            It.IsAny<string>()))
            .Callback((string cookieToken, string formToken) =>
                                {
                                    // call back
                                });
    antiForgeryMock.Verify(m => m.Validate(
            It.IsAny<string>(),
            It.IsAny<string>()), Times.Once());
