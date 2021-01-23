    public class Logger
    {
        public Logger(string name)
        {
        }
    }
    public class LogResolver : ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
                               DependencyModel dependency)
        {
            return dependency.TargetType == typeof(Logger);
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
                              DependencyModel dependency)
        {
            return new Logger(model.Name);
        }
    }
