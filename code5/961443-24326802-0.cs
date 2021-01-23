    public void Test()
    {
        var sut = new MyClass();
        var input = MockRepository.GenerateStub<A>();
        sut.MyMethod(input);
        Assert.AreEqual(1, input.Errors.Count);
    }
