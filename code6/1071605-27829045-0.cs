    using System.Windows;
    using SimpleInjector;
    
    public partial class App : Application
    {
        private static Container container;
    
        [System.Diagnostics.DebuggerStepThrough]
        public static TService GetInstance<TService>() where TService : class {
            return container.GetInstance<TService>();
        }
    
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            Bootstrap();
        }
    
        private static void Bootstrap()  {
            // Create the container as usual.
            var container = new Container();
    
            // Register your types, for instance:
            container.RegisterSingle<IImageManager>(() => new CachedImageManager(new SystemImageManager()););
            
            // Optionally verify the container.
            container.Verify();
    
            // Store the container for use by the application.
            App.container = container;
        }
    }
