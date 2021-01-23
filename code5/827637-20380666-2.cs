    public class TestClass implements IEquatable
    {
        protected string teststring;
        protected int testint;
    
        public string TestString
        {
            get { return teststring; }
            set { teststring = value; }
        }
        public int TestInt
        {
            get { return testint; }
            set { testint = value; }
        }
        public override bool Equals(object y)
        {
            TestClass newY = y as TestClass;
            if (newY == null) { return false; }
            return newY.TestString == this.TestString &&
                newY.TestInt == this.TestInt;
        }
        public override int GetHashCode()
        {
            // use this example or implement some hash code logic
            return this.TestInt.GetHashCode() ;
        }
        public TestClass() { }
    }
