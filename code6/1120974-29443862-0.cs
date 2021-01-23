    public delegate void Bar(object obj);
    public class Foo
    {
       public Bar MyBar { get; set; }
    }
    public class FooEntity
    {
       public Bar MyBar { get; set; }
    }
