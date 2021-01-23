    public void TestMethod1()
    {
        var anonItem = new
        {
            p1 = 100,
            p2 = "string"
        };
        var a = Util.Create(anonItem);
        var b = GetAsTestClass(a, anonItem);
        // this will be "null" in this example
        // So, how can I convert back to its real type?
        // And get the "member" data
        var c = b.member;
        Assert.AreEqual(100, c.p1);
    }
    public TestClass<T> GetAsTestClass<T>(ITestInterface item, T silentType)
    {
        return item as TestClass<T>;
    }
