    public abstract class SuperPlugin : IPlugin{
           public void Execute(IServiceProvider serviceProvider){
                // initialize a static container instance if not available
                var containerWrapper = new ContainerWrapper{
                    Container = serviceProvider.GetService(typeof(IPluginExecutionContext)),
                    Resolver = //static resolver instance of dependency container
                };
                OnExecution(containerWrapper);
           }
           public abstract void OnExecution(IDependencyResolver resolver);
    }
