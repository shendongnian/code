    public class AppBootstrapper : BootstrapperBase {
        SimpleContainer container;
        public AppBootstrapper() {
            Initialize();
        }
        protected override void Configure() {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, ModernWindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<IShell, ModernWindowViewModel>();
            // Register viewmodels etc here....
        }
 
        // IoC.Get<T> or IoC.GetInstance(Type type, string key) ....
        protected override object GetInstance(Type service, string key) {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("Could not locate any instances.");
        }
        // IoC.GetAll<T> or IoC.GetAllInstances(Type type) ....
        protected override IEnumerable<object> GetAllInstances(Type service) {
            return container.GetAllInstances(service);
        }
        // IoC.BuildUp(object obj) ....
        protected override void BuildUp(object instance) {
            container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) {
            DisplayRootViewFor<IShell>();
        }
