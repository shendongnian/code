        public class BaseClass
        {
            protected readonly ushort OffsetRoutine;
            protected readonly ushort OffsetString;
            public BaseClass(ushort value1, ushort value2)
            {
                OffsetRoutine = value1;
                OffsetString = value2;
            }
        }
        public class DerivedClass : BaseClass
        {
            public DerivedClass(ushort value1, ushort value2)
                : base(value1, value2)
            {
            }
        }
