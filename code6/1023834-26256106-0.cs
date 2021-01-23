    public class DerivedClass : BaseClass
    {
        public DerivedClass() { }
        public DerivedClass(string TestName, uint TestNumber)
        {
            base.TestName = TestName;
            base.TestNumber = TestNumber;
        }
        public DerivedClass(BaseClass bc) : this(bc.TestName, bc.TestNumber) { }
    }
