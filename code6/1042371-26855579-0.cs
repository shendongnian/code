    [SetUp]
    public void Setup()
    {
        _modelMapper = Substitute.For<IModelMapper>();
        theClass = new TheClass(_modelMapper);
    }
    [Test]
    public void GetModel_Returns_Model_From_Mapper()
    {
        // Arrange
        var booking = new Booking { CurrencyCode = "" };
        var expectedModel = new BasketModel();
        _modelMapper.GetModel(booking).Returns(expectedModel);
        // Act
        var result = theClass.GetModel(booking, null);
        // Assert
        Assert.AreSame(expectedModel, result);
    }
    
