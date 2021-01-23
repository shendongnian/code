    [Theory, InlineAutoData]
    public void DoSomethingRetunrsCorrectResult(MyClass sut, int input)
    {
        var expected = input < 10 ? input + 1 : input * 10;
        var actual = sut.DoSomething(input);
        Assert.Equal(expected, actual);
    }
