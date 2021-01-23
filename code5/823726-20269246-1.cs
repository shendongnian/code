    private Foo _foo;
    [SetUp]
    public void Setup()
    {
        _foo = new Foo();;
    }
    [Test]
    public void test1()
    {
        _foo.Start();
        // Assert 
    }
    [TearDown]
    public void TearDown()
    {
        if (_foo != null)
          _foo.Stop();
    }
