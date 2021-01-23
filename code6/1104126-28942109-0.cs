    public static int Calculate(int a, int b)
    {
       var dependency = new Dependency();
       dependency.CheckSecurity("typemock", "rules");
       return a + b;
    }
    [TestMethod,Isolated]
    public void FakeConstructor()
    {
        // Fake the Dependency constructor
        var fakeHandle = Isolate.Fake.NextInstance<dependency>();
        var result = ClassUnderTest.Calculate(1, 2);
        Assert.AreEqual(3, result);
    }
