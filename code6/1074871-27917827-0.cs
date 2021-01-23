    public class TestClass
    {
        Dictionary<string,double> values = new Dictionary<string,double>
        public Dictionary<string,double> Values {get {return this.values; }}
        public string Name {get;set;}
    }
    TestClass testClass = new TestClass();
    testClass.Values["Value1"] = 5.5;
