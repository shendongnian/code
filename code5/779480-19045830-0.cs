    [Test]
    public void TestUser()
    {
        MyClass myClass = new MyClass();
        MyClass.userid = "test value";
        Assert.IsTrue(IsEntryExist())
    }
