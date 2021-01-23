    [Test]
    public void SomeMethod_InvalidParameter_CallsLogger
    {
        Rhino.Mocks.MockRepository mockRepository = new Rhino.Mocks.MockRepository();
        IStringAnalyzer s = mockRepository.Stub<IStringRepository>();
        s.Stub(s => s.IsValid("something, doesnt matter").IgnoreParameters().Return(false);
        ILogger l = mockRepository.DynamicMock<ILogger>();
        SomeClass someClass = new SomeClass(s, l);
        mockRepository.ReplayAll();
    
        someClass.SomeMethod("What you put here doesnt really matter because the stub will always return false");
    
        l.AssertWasCalled(l => l.Log("Invalid string"));
    }
