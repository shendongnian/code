    public class TestClass
    {
       
        [XmlIgnore]
        public int TestVariable
        {
            get;
            set;
        }
        public int ControlVariable
        {
            get;
            set;
        }
        public TestClass()
        {
            TestVariable = 1000;
            ControlVariable = 9999;
        }
    }
