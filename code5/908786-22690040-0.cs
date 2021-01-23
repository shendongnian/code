    public class LoggingInterceptor : IInterceptor
    {
        public ILogger Logger { get; set; }
        public void Intercept(IInvocation invocation)
        {
            Logger.Debug(() =>
            {
                return String.Format("calling {0}.{1}"
                                   , invocation.TargetType.Name
                                   , invocation.Method.Name);
                // add whatever information is important
                // you can even dump the values of your parameters
            });
            invocation.Proceed();
        }
    }
