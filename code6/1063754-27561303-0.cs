    class MyClass : ILinked<MyParameter> {
        public ICollection<MyParameter> SomeArbitraryProperty { get; set; }
        ICollection<MyParameter> ILinked<MyParameter>.LinkedT
        { 
            get { return SomeArbitraryProperty; }
            set { SomeArbitraryProperty = value; }
        }
    }
