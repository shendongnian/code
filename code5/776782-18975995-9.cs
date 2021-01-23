    [TestMethod]
    public void PropertyFoo_StoresCorrectly()
    {
       var sut = new MyClass();
       sut.Foo = "hello";
       Assert.AreEqual("hello", sut.Foo, "Oops...");
    }
