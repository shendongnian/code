    [TestMethod]
    public void ContentValidator_ShouldHaveErrorWhenPositionLessThanOne()
    {
        _validator.ShouldHaveValidationErrorFor(e => e.Position, (short)0);
    }
    
    [TestMethod]
    public void ContentValidator_ShouldHaveErrorWhenPositionGreaterThanTwoHundredAndFiftyFive()
    {
        _validator.ShouldHaveValidationErrorFor(e => e.Position, (short)256);
    }
    
    [TestMethod]
    public void ContentValidator_ShouldHaveErrorWhenWidthLessThanOne()
    {
        _validator.ShouldHaveValidationErrorFor(e => e.Width, (short)0);
    }
    
    [TestMethod]
    public void ContentValidator_ShouldHaveErrorWhenWidthGreaterThanTwelve()
    {
        _validator.ShouldHaveValidationErrorFor(e => e.Width, (short)13);
    }
