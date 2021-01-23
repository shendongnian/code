    public void TestMethod()
    {
        MyClass testObj = new MyClass(1, new MockService());
         
        testObj.RefreshAmount();
        Assert.Equals(10, testObj.Number);
    }
