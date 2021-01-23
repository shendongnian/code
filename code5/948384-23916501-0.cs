    namespace ClassLibrary1
    {
        public class Class1
        {
            public int Property1 { get; set; }
        }
    }
    [TestMethod]
    public void TestMethod1()
    {
        var test = new Class1();
        Assert.IsNotNull(test);
    }
