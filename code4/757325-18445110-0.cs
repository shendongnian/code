    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestFooForNull()
    {
        Foo(null);
    }
    
    
    [Test]
    [ExpectedException(typeof(MyException))]
    public void TestFooForInvalidSizeTooShort()
    {
        Foo("1234");
    }
    
    
    [Test]
    [ExpectedException(typeof(MyException))]
    public void TestFooForInvalidSizeTooLong()
    {
        Foo("123456");
    }
    
    
    [Test]
    public void TestFoo()
    {
        Foo("12345");
    }
