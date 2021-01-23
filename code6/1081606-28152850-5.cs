    internal class FooBuilder
    {
    
        public string Prop1 { get; private set; }
        public string Prop2 { get; private set; }
    
        // default constructor, provide default values
        public FooBuilder()
        {
            this.Prop1 = "test";
            this.Prop2 = "another value";
        }
    
        public FooBuilder WithProp1(string prop1)
        {
            this.Prop1 = prop1;
            return this;
        }
        public FooBuilder WithProp2(string prop2)
        {
            this.Prop2 = prop2;
            return this;
        }
    
        public Foo Build()
        {
            return new Foo(
                this.Prop1,
                this.Prop2
            );
        }
    }
