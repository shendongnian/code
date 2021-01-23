    public void TestWhenTrue()
    {
        var classUnderTest = new ClassToTest();
        Assert.IsString(classUnderTest.IsSet(true));
    }
    public void TestWhenFalse()
    {
        var classUnderTest = new ClassToTest();
        Assert.IsString(classUnderTest.IsSet(false));
    }
