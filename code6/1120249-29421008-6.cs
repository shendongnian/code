    _kernel.Bind<IFoo>().To<MyFoo>();
    _kernel.Bind<IBar>().To<Bar1>(); //ContextType.Site
    _kernel.Bind<IBar>().To<Bar2>(); //ContextType.Local
    _kernel.Bind<IBar>().To<Bar3>(); 
    
    public class Foo: IFoo
    {
        private readonly Dictionary<ContextType, IBar> _bars;
        public Foo(IBar[] bars)
        {
            _bars= bars.ToDictionary(x => x.ContextType);
        }
    }
