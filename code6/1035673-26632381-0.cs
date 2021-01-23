    class MyImmutableRefClass
    {
        public readonly object ReferenceStrig;
        public readonly int IntegerValue;
        public MyImmutableRefClass(): this("Initialized string", 100)
        {
        }
        public MyImmutableRefClass(string referenceStrig, int integerValue)
        {
            ReferenceStrig = referenceStrig;
            IntegerValue   = integerValue;
        }
    }
