    [Theory]
    [InlineData(7), false]
    [InlineData(13), true]
    [InlineData(4), false]
    public void MyTest(int num, bool expectedResult)
    {
        bool res = MyCompMethod(num);
        Assert.Equal(expectedResult, res);
    }
