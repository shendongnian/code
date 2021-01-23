    public class Foo<T>
        where T : Foo.Bar
    {
        private T _bar = new T();
        public class Bar
        {
            public virtual void DoSomething() { ... }
        }
    }
    public class BarDerived : Foo.Bar
    {
        public override void DoSomething() { ... }
    }
    public class Quz : Foo<BarDerived> { ... }
