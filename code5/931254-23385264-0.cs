    public class LoggingInterceptor : IInterceptor
    {
        public LoggingInterceptor([NotNull] object target, [NotNull] ILog logger)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            this.Target = target;
            this.Logger = logger;
        }
        public object Target { get; set; }
        public ILog Logger { get; set; }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                this.Logger.Debug(invocation);               
                invocation.ReturnValue = invocation.Method.Invoke(
                    this.Target, invocation.Arguments);
                this.Logger.Debug("Invocation return value:");
                this.Logger.Debug(invocation.ReturnValue);
            }
            catch (TargetInvocationException ex)
            {
                this.Logger.Error("Unable to execute invocation", ex);
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw;
            }
        }
    }
