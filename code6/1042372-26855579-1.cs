    [Test]
    public void ModelReturnedShouldBeFormatted()
    {
        // Arrange
        var booking = new Booking { CurrencyCode = "" };
        var expectedModel = Substitute.For<IBasketModel>();
        _modelMapper.GetModel(booking).Returns(expectedModel);
        // Act
        var result = theClass.GetModel(booking, null);
        // Assert
        expectedModel.Received().FormatModel(Arg.Any<SomethingHere>());
    }
