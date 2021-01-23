    public class CatalogManager : IDisposable
    {
        [ImportMany(typeof (IPlugin), AllowRecomposition = true)] 
        private IEnumerable<IPlugin> _plugins;
        private CompositionContainer _container;
        public CompositionContainer Container
        {
            get { return _container; }
        }
        public IEnumerable<IPlugin> Plugins
        {
            set { _plugins = value; }
        }
        private CatalogManager(string pluginsDir)
        {
            var catalog = new AggregateCatalog();
            //--load all plugin from plugin directory
            if (Directory.Exists(pluginsDir))
                catalog.Catalogs.Add(new DirectoryCatalog(pluginsDir));
            //--load all plugin from executing assembly
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            Initialize(catalog);
        }
        private void Initialize(AggregateCatalog catalog)
        {
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }
        public void Dispose()
        {
            if (_container == null)
                return;
            _container.Dispose();
            _container = null;
        }
    }
