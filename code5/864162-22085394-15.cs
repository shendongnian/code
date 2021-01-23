    internal class PluginDomain : IDisposable
    {
        private readonly string _name;
        private readonly string _pluginDllPath;
        private readonly AppDomain _domain;
        private readonly PluginDomainDependencyResolver _container;
        public PluginDomain(string name, string pluginDllPath)
        {
            _name = name;
            _pluginDllPath = pluginDllPath;
            _domain = CreateAppDomain();
            _container = CreateInstance<PluginDomainDependencyResolver>();
        }
        public AppDomain CreateAppDomain()
        {
            var domaininfo = new AppDomainSetup
            {
                PrivateBinPath = _pluginDllPath
            };
            var evidence = AppDomain.CurrentDomain.Evidence;
            return AppDomain.CreateDomain(_name, evidence, domaininfo);
        }
        private T CreateInstance<T>()
        {
            var assemblyName = typeof(T).Assembly.GetName().Name + ".dll";
            var typeName = typeof(T).FullName;
            if (typeName == null)
                throw new Exception(string.Format("Type {0} had a null name.", typeof(T).FullName));
            return (T)_domain.CreateInstanceFromAndUnwrap(assemblyName, typeName);
        }
        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
        public void Dispose()
        {
            DestroyAppDomain();
        }
        private void DestroyAppDomain()
        {
            AppDomain.Unload(_domain);
        }
    }
