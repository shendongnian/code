    public class TestClass
    {
        public override bool Equals(object y)
        {
            TestClass newY = y as TestClass;
            if (newY == null) { return false; }
            return newY.TestString == this.TestString &&
                newY.TestInt == this.TestInt;
        }
        public override int GetHashCode()
        {
            // implement some hash code algorithm
        }
    }
