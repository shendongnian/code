    public void MyTest()
    {
        var expectedList = new List<string> { "SomeFunction", "AnotherFunction", ... };
        var actualList = new List<string>();
        mockStream.Setup(x => x.SomeFunction()).Callback(actualList.Add("SomeFunction"));
        ...
        systemUnderTest.Bar(...);
        Assert.That(actualList, Is.EqualTo(expectedList));
        mockStream.VerifyAll();
    }
