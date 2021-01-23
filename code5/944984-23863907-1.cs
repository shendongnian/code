    public void SomeTestMethod()
    {
        var session = new MyTypedSession { IsAuthenticated = true; };
    
        //get your container and register the session
        container.Register(session);
    
        var someValue = TestCodeThatUsesASession();
    
        Assert(someValue);
    }
