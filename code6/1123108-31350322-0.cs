    [Export(typeof(IWindowManager))]
    public class MyWindowManager : WindowManager
    {
    }
    [Export(typeof(IEventAggregator))]
    public class MyEventAggregator : EventAggregator
    {
    }
    public interface IShell
    {
    }
    public class AppBootstrapper : BootstrapperBase
    {
        private CompositionHost _host;
        public AppBootstrapper()
        {
            Initialize();
        }
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            // TODO: Add additional assemblies here
            yield return typeof(AppBootstrapper).GetTypeInfo().Assembly;
        }
        protected override void Configure()
        {
            var config = new ContainerConfiguration();
            var assemblies = AssemblySource.Instance.Union(SelectAssemblies());
            config.WithAssemblies(assemblies);
            _host = config.CreateContainer();
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            var exports = _host.GetExports(serviceType, key).ToArray();
            if (exports.Any())
                return exports.First();
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", serviceType.Name));
        }
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _host.GetExports<object>(serviceType.ToString());
        }
        protected override void BuildUp(object instance)
        {
            _host.SatisfyImports(instance);
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
