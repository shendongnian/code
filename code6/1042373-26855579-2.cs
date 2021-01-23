    [Test]
    public void FormatModel()
    {
        // Arrange
        var booking = new Booking { CurrencyCode = "" };
        var expectedModel = Substitute.For<IBasketModel>();
        expectedModel
           .When(x => x.FormatModel(Arg.Any<SomethingHere>()))
           .Do(/* some action */);
        _modelMapper.GetModel(booking).Returns(expectedModel);
        // Act
        var result = theClass.GetModel(booking, null);
        // Assert
        // assertion here that depends on "some action" and result
    }
