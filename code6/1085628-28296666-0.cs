    public class Foo<T>
    {
        public Foo(string s, T t) { }
    }
    var foo = new Foo("Hello", new Something());
