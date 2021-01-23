    public class Foo
    {
        public string Prop1 { get; private set; }
    
        public Foo(string prop1)
        {
            this.Prop1 = prop1;
        }
    }
    
    [TestClass]
    public class FooTests
    {
        [TestMethod]
        public void SomeTestThatRequiresAFoo()
        {
            Foo f = new Foo("a");
            // testy stuff
        }
    
        [TestMethod]
        public void SomeTestThatRequiresAFooUtilizingBuilderPattern()
        {
            Foo f = new FooBuilder().Build();
        }
        [TestMethod]
        public void SomeTestThatRequiresAFooUtilizingBuilderPatternOverrideDefaultValue()
        {
            Foo f = new FooBuilder()
               .WithProp1("different than default")
               .Build();
        }
    }
    
    internal class FooBuilder
    {
    
        public string Prop1 { get; private set; }
    
        // default constructor, provide default values
        public FooBuilder()
        {
            this.Prop1 = "test";
        }
    
        public FooBuilder WithProp1(string prop1)
        {
            this.Prop1 = prop1;
            return this;
        }
    
        public Foo Build()
        {
            return new Foo(
                this.Prop1
            );
        }
    }
