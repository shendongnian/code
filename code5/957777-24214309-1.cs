    public class WebFormsDependencyInjectionHttpModule : IHttpModule {
        public static UnityContainer Container;
        private HttpApplication application;
        public void Init(HttpApplication context) {
            this.application = context;
            context.PreRequestHandlerExecute += this.PreRequestHandlerExecute;
        }
        public void Dispose() { }
        internal static void InitializeInstance(object instance) {
            Container.BuildUp(instance);
        }
        private void PreRequestHandlerExecute(object sender, EventArgs e) {
            if (Container == null) 
                throw new InvalidOperationException("Set Container first.");
            var handler = this.application.Context.CurrentHandler;
            if (handler != null) {
                InitializeHttpHandler(handler);
            }
        }
        private void InitializeHttpHandler(IHttpHandler handler) {
            InitializeInstance(handler);
            if (handler is Page) {
                PageInitializer.HookEventsForUserControlInitialization((Page)handler);
            }
        }
        private sealed class PageInitializer { ... }
    }
