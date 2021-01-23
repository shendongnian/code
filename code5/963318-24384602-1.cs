    [Test]
    public void TestFoo()
    {
        var handler = MockRepository.GenerateMock<IExceptionHandler>();
        var obj = new Myclass(handler);
        obj.Count = 4;
        obj.Foo();
        
        handler.AssertWasCalled(h => h.Handle(Arg<Exception>.Is.Anything));
    }
