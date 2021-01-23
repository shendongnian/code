    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void LengthHasMinimum()
    {
        // arrange
        var rectangle = new Rectangle();
        // act
        rectangle.Length = 0.0;
        // assert
        //  nothing to assert
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void LengthHasMaximum()
    {
        // arrange
        var rectangle = new Rectangle();
        // act
        rectangle.Length = 20.0;
        // assert
        //  nothing to assert
    }
