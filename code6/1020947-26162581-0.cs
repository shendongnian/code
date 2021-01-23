    [Test]
    public void Test()
    {
        var expectedInput = new Object1 { DeeperObject = new Object2 { MyString = "Hello World" } };
        const string expectedOutput = "Hello Matt!";
        _mockOne.Expect(s => s.ReturnSomething(expectedInput))
                .Return(expectedOutput);
        var actualInput = new Object1 { DeeperObject = new Object2 { MyString = "Hello World" } };
        var actualOutput = _mockOne.ReturnSomething(actualInput);
        Assert.NotNull(actualOutput);
    }
