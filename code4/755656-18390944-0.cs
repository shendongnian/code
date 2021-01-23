    public interface IFoo
    {
    }
    public class Foo: IFoo  // implements the IFoo interface
    {
    }
    public interface IBar
    {
    }
    public class Bar: IBar
    {
    }
    public class MyWrapper: IFoo, IBar  // Implements the IFoo and IBar interfaces
    {
        private IFoo _theFoo;
        private IBar _theBar;
        public MyWrapper(IFoo foo, IBar bar)
        {
            _theFoo = foo;
            _theBar = bar;
        }
    }
