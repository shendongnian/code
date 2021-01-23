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
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + this.TestInt.GetHashCode();
                hash = hash * 23 + this.TestString == null ?
                    0 :
                    this.TestString.GetHashCode();
                return hash;
            }
        }
    }
