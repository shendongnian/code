        public class Factory
        {
            private readonly IIndex<string, ISearchService> _index;
        
            public Factory(IIndex<string, ISearchService> index)
            {
                _index = index;
            }
        
            public ISearchService Resolve(string id)
            {
                return _index[id];
            }
        }
            
            // Registrations
            var builder = new ContainerBuilder();
            builder.Register<ASearchService>(c => new ASearchService()).Keyed<ISearchService>("A");
            builder.Register<BSearchService>(c => new BSearchService()).Keyed<ISearchService>("B");
            builder.Register<Factory>(c => new Factory(c.Resolve<IIndex<string, ISearchService>>()));
            // as per autofac's page linked above, autofac automatically implements IIndex types
            
            // Usage
            
            var aSearchService = fact.Resolve("A");
