    using(mockGood = AutoMock.GetLoose())
    using(mockBad = AutoMock.GetLoose())
    {
        var goodHW = mockGood.Create<IHW>();
        ((Mock<IHW>)goodHW).Setup(x => x.OK).Returns(true);
    
        var badHW = mockBad.Create<IHW>();
        ((Mock<IHW>)badHW).Setup(x => x.OK).Returns(false);
    
        mockGood.Mock<IHWManager>().SetupGet(x => x.HW1).Returns(goodHW);
        mockBad.Mock<IHWManager>().SetupGet(x => x.HW2).Returns(badHW);
    
        Assert.AreNotEqual(goodHW, badHW) // SUCCESS??
    }
