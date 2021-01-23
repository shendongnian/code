    var mockCodeService = new Mock<ICodeService>();
    mockCodeService.Setup(x => x.GetAllCodes())
        .Returns(currencycodes); // Now we don't care whether this is from cache or db 
   
    var higherLevelClassUsingCodeService = new SomeClass(mockCodeService.Object);
    higherLevelClassUsingCodeService.DoSomething();
    mockCodeService.Verify(x => x.GetAllCodes(), Times.Once); // etc
