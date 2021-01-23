    [TestMethod]
    public void YearOfManufacture_Is_Required()
    {
        // arrange
        var sut = new MyViewModel();
        sut.YearOfManufacture = null;
        ICollection<ValidationResult> results;
        
        // act
        var actual = TryValidate(sut, out results);
        
        // assert
        Assert.IsFalse(actual);
    }
