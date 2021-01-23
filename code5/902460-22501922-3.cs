    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var proxyGenerator = new ProxyGenerator();
            var testObject = proxyGenerator.CreateClassProxy<Test>();
            Console.WriteLine(
                testObject.Status != null 
                ? "Working" 
                : "no....");
        }
    }
    
    public class Test
    {
        private SubTestClass subTestClass = new SubTestClass();
    
        public string Status
        {
            get
            {
                return this.subTestClass.SubStatus;
            }
    
            set
            {
                this.subTestClass.SubStatus = value;
            }
        }
    
        public int Data { get; set; }
    }
    
    public class SubTestClass
    {
        public SubTestClass()
        {
            SubStatus = "";
        }
        public string SubStatus { get; set; }
    }
