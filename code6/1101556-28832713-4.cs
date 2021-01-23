    public class Pouet
    {
        public Pouet(Foo foo) { }
    }
    public class Foo
    {
        public Foo(IBar bar) { }
    }
    public interface IBar { }
    public class Bar1 : IBar { }
    public class Bar2 : IBar { }
