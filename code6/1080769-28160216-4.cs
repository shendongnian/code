    public class ContainerSingleton
    {
        private static CompositionContainer compositionContainer;
    
        public static CompositionContainer ContainerInstance
        {
            get 
            {
                if (compositionContainer == null)
                {
                    var appDomainName = AppDomain.CurrentDomain.FriendlyName;
                    throw new Exception("Composition container is null and must be initialized through the ContainerSingleton.Initialize()" + appDomainName);
                }
                return compositionContainer; 
            }
        }
    
        public static ContainerSingleton()
        {
            var catalog = new AggregateCatalog();
            //this directory should have all the defaults
            var dirCatalog = new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //add system type plug-ins, too
            catalog.Catalogs.Add(dirCatalog);
    
            compositionContainer = new CompositionContainer(catalog);
        }
    }
