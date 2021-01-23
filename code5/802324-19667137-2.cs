    public class foo : bar
    {
        // IS-A
    }
    public interface IBar
    {
    }
    public class Bar : IBar
    {
    }
    public class Foo : IBar
    {
        private Bar _bar;
    
        public foo(Bar bar)
        {
            _bar = bar;
    
        }
    
        // HAS-A
    }
