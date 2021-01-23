        public delegate TReturn AutoFactoryDelegate<TParam, TReturn>(TParam param);
    
        public class AutoFactory<TParam, TReturn>
        {
            private readonly IIndex<TParam, TReturn> _index;
    
            public AutoFactory(IIndex<TParam, TReturn> index)
            {
                _index = index;
            }
    
            public TReturn Resolve(TParam param)
            {
                return _index[param];
            }
        }
    
        public delegate TReturn AutoFactoryDelegate<TParam, TReturn>(TParam param);
    
        public static class AutofacExtensions
        {
            public static void RegisterAutoFactoryDelegate<TParam, TReturn>(this ContainerBuilder builder)
            {
                builder.Register(c => new AutoFactory<TParam, TReturn>(c.Resolve<IIndex<TParam, TReturn>>()));
    
                builder.Register<AutoFactoryDelegate<TParam, TReturn>>(c =>
                   {
                     var fact = c.Resolve<AutoFactory<TParam, TReturn>>();
                     return fact.Resolve;
                   });
            }
        }
    
    // Registration
    var builder = new ContainerBuilder();
    builder.Register<ASearchService>(c => new ASearchService()).Keyed<ISearchService>("A");
    builder.Register<BSearchService>(c => new BSearchService()).Keyed<ISearchService>("B");
    builder.RegisterAutoFactoryDelegate<string, ISearchService>();
    
    // Usage
    // fact is an AutoFactoryDelegate<string, ISearchService>
    var aSearchService = fact("A");
