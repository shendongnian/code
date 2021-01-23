    public class Foo2<T>
    {
        [ThreadStatic]
        public Func<T, int> Generator { get; set; }
    }
