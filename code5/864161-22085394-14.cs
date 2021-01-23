    [Serializable]
    internal class PluginDomainDependencyResolver : MarshalByRefObject
    {
        private readonly IContainer _container;
        private readonly List<string> _typesThatFailedToResolve = new List<string>();
 
        public PluginDomainDependencyResolver()
        {
            _container = BuildContainer();
        }
 
        public T Resolve<T>() where T : class
        {
            var typeName = typeof(T).FullName;
            var resolveWillFail = _typesThatFailedToResolve.Contains(typeName);
            if (resolveWillFail)
                return null;
            var instance = ResolveIfExists<T>();
            if (instance != null)
                return instance;
            _typesThatFailedToResolve.Add(typeName);
            return null;
        }
 
        private T ResolveIfExists<T>() where T : class
        {
            T instance;
            _container.TryResolve(out instance);
            return instance;
        }
 
        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
 
            var assemblies = LoadAssemblies();
            builder.RegisterAssemblyModules(assemblies); // Should we allow plugins to load dependencies in the Autofac container?
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(ITestPlugin).IsAssignableFrom(t))
                .As<ITestPlugin>()
                .SingleInstance();
 
            return builder.Build();
        }
 
        private static Assembly[] LoadAssemblies()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + PluginHost.PluginRelativePath;
            if (!Directory.Exists(path))
                return new Assembly[]{};
            var dlls = Directory.GetFiles(path, "*.dll").ToList();
            dlls = GetAllDllsThatAreNotAlreadyLoaded(dlls);
            var assemblies = dlls.Select(LoadAssembly).ToArray();
            return assemblies;
        }
 
        private static List<string> GetAllDllsThatAreNotAlreadyLoaded(List<string> dlls)
        {
            var alreadyLoadedDllNames = GetAppDomainLoadedAssemblyNames();
            return dlls.Where(dll => !IsAlreadyLoaded(alreadyLoadedDllNames, dll)).ToList();
        }
 
        private static List<string> GetAppDomainLoadedAssemblyNames()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return assemblies.Select(a => a.GetName().Name).ToList();
        }
 
        private static bool IsAlreadyLoaded(List<string> alreadyLoadedDllNames, string file)
        {
            var fileInfo = new FileInfo(file);
            var name = fileInfo.Name.Replace(fileInfo.Extension, string.Empty);
            return alreadyLoadedDllNames.Any(dll => dll == name);
        }
 
        private static Assembly LoadAssembly(string path)
        {
            return Assembly.Load(File.ReadAllBytes(path));
        }
    }
