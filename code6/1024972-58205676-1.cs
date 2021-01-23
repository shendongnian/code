     public static class ObjectFactory
        {
            private static readonly CompositionContainer _container;
        
            [ImportMany]
            public static IEnumerable<Lazy<IClass, IMetaData>> objectTypes;
            static ObjectFactory()
            {
                AggregateCatalog catalog = new AggregateCatalog();
        
                catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory));
                _container = new CompositionContainer(catalog);
        
            }
        //get object method
            public static T CreateObject<T>(string objectType)
            {
                try
                    {
                        return _container?.GetExportedValueOrDefault<T>(objectType);
                    }
                    catch (Exception)
                    {
                    }
                    return null;
            }
        }
    
   
