    public class WebApplication : HttpApplication, IContainerAccessor {
      static IWindsorContainer container;
    
      public IWindsorContainer Container {
        get { return container; }
      }
    
      protected void Application_Start() {
        var bootstrapper = new WindsorConfigTask();
        bootstrapper.Execute();
        container = bootstrapper.Container; 
      }
    
      protected void Application_End() {
        container.Dispose();
      }
    }
