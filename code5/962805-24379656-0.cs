    Kernel.Bind<ILoggerFactory>().To<MyCustomLoggerFactory>();
    IBindingRoot.Bind<ILogger>().ToProvider<LoggerProvider>();
    public class LoggerProvider : Provider<ILogger> {
        private readonly ILoggerFactory factory;
        public LoggerProvider(ILoggerFactory factory)
        {
             this.factory = factory;
        }
        protected override T CreateInstance(IContext context)
        {
             return this.factory.GetLogger(context.Request.ParentRequest.Service);
        }
    }
