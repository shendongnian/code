    abstract class A
    {
        public static A GetNextA(AType type)
        {
            switch (type)
            {
                case AType.A1: return new A1();
                case AType.A2: return new A2();
                default: return null;
            }
        }
        public abstract AType DoSomething();
    }
    class Master
    {
        public A a;
        public void DoSomething()
        {
            AType nextAType = a.DoSomething();
            a = A.GetNextA(nextAType);
        }
    }
    class A1 : A
    {
        public override AType DoSomething()
        {
            //do Work
            return AType.A2;
        }
    }
    class A2 : A
    {
        public override AType DoSomething()
        {
            //do Different Work
            return AType.A1;
        }
    }
    enum AType
    {
        A1,
        A2
    }
