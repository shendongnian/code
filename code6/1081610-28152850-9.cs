    internal class FooBuilder
    {
    
        public string Prop1 { get; private set; }
        public string Prop2 { get; private set; }
    
        // default constructor, provide default values to Foo object
        public FooBuilder()
        {
            this.Prop1 = "test";
            this.Prop2 = "another value";
        }
    
        // Sets the "Prop1" value and returns this, done this way to create a "Fluent API"
        public FooBuilder WithProp1(string prop1)
        {
            this.Prop1 = prop1;
            return this;
        }
        // Similar to the "WithProp1"
        public FooBuilder WithProp2(string prop2)
        {
            this.Prop2 = prop2;
            return this;
        }
    
        // Builds the Foo object by utilizing the properties created as BuilderConstruction and/or the "With[PropName]" methods.
        public Foo Build()
        {
            return new Foo(
                this.Prop1,
                this.Prop2
            );
        }
    }
