    [TestMethod]
    public void RectangleHasDefaults()
    {
        // arrange
        var rectangle = new Rectangle();
        // act
        //  no action to perform
        // assert
        Assert.AreEqual(1.0, rectangle.Length);
        Assert.AreEqual(1.0, rectangle.Width);
    }
