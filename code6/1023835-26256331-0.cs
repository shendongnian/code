    public class TestData
    {
        public string TestName { get; set; }
        public uint TestNumber { get; set; }
    }
    
    public class BaseClass
    {
        protected TestData data;
        public BaseClass(TestData data)
        {
            this.data = data;
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public DerivedClass(TestData data)
           : base(data)
        {
        }
    }
