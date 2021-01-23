    [TestMethod]
    public void RectangleHasPerimeter()
    {
        // arrange
        var rectangle = new Rectangle();
        // act
        rectangle.Length = 2.0;
        rectangle.Width = 3.0;
        // assert
        Assert.AreEqual(10.0, rectangle.Perimeter);
    }
    [TestMethod]
    public void RectangleHasArea()
    {
        // arrange
        var rectangle = new Rectangle();
        // act
        rectangle.Length = 2.0;
        rectangle.Width = 3.0;
        // assert
        Assert.AreEqual(6.0, rectangle.Area);
    }
