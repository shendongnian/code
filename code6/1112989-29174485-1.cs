    [TestMethod]
    public void CalculateSomething1_FooInput
    {
        var input = new SomeInput1("Foo");
        var expected = new SomeOutput1(...);
        var actual = CreateTestCalculateSomething().CalculateSomething1(input);
        AssertSomeOutput1Equality(expected, actual);
    }
