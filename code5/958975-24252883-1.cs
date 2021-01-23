    public class Foo
        {
            public int Id { get; set; }
            public int DisplayOrder { get; set; }
            public string Description { get; set; }
            public string Package { get; set; }
            public Byte[] TimeStamp { get; set; }
        }
        public class LookupType : Foo
        {
            public LookupType(){}
            public LookupType(string value)
            {
                Description = value;
            }
            public string Description { get; set; }
            // A few other properties
        }
        public class BarTypeA : LookupType
        {
            public BarTypeA() { }
            public BarTypeA(string value) : base(value) { }
        }
        public class BarTypeB : LookupType
        {
            public BarTypeB() { }
            public BarTypeB(string value) : base(value) { }
        }
        public class BarTypeC : LookupType
        {
            public BarTypeC() { }
            public BarTypeC(string value) : base(value) { }
        }
