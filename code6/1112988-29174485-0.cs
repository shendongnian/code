    [TestMethod]
    public void CalculateSomething1_FooInput
    {
        var input = new SomeInput1("Foo");
        var expected = new SomeOutput1(...);
        var calc = new CalculateSomething(...);
        var actual = calc.CalculateSomething1(input);
        Assert.AreEqual(expected.Prop1, actual.Prop1);
        Assert.AreEqual(expected.Prop2, actual.Prop2);
        Assert.AreEqual(expected.Prop3, actual.Prop3);
    }
