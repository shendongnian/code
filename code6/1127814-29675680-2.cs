    [Theory]
    [InlineData(7, false)]
    [InlineData(13, true)]
    [InlineData(4, false)]
    public void MyTest(int num, bool shouldBeGreaterThanTen)
    {
        bool isGreaterThanTen = MyCompMethod(num);
        Assert.Equal(shouldBeGreaterThanTen, isGreaterThanTen);
    }
