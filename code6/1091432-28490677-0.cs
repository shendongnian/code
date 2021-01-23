    public class Bar<TReturn>
        where TReturn : Bar<TReturn>
    {
        public TReturn Baz()
        {
            return this as TReturn;
        }
    }
    public class Foo : Bar<Foo>
    {
    }
    class Test 
    {
        public void Main()
        {
            var foo = new Foo();
            var foo2 = foo.Baz();
            Assert.IsInstanceOfType(foo.GetType(), foo2);
        }
    }
