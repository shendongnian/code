    public class Foo<T>
    {
        public Foo(T t, string s) { }
    }
    var foo = new Foo(new Something(), "Hello");
