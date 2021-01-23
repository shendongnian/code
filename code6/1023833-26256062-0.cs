    public class DerivedClass : BaseClass
    {
        public DerivedClass () {}
        public DerivedClass ( BaseClass bc )
        {
            TestName=bc.TestName;
            TestNumber=bc.TestNumber;
        }
    }
