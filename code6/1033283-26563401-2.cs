    [Theory, InlineAutoData]
    public void DoSomethingWhenInputIsLowerThan10ReturnsCorrectResult(
        MyClass sut,
        [Range(int.MinValue, 9)]int input)
    {
        Assert.True(input < 10);
        var expected = input + 1;
            
        var actual = sut.DoSomething(input);
            
        Assert.Equal(expected, actual);
    }
    [Theory, InlineAutoData]
    public void DoSomethingWhenInputIsEqualsOrGreaterThan10ReturnsCorrectResult(
        MyClass sut,
        [Range(10, int.MaxValue)]int input)
    {
        Assert.True(input >= 10);
        var expected = input * 10;
        var actual = sut.DoSomething(input);
        Assert.Equal(expected, actual);
    }
