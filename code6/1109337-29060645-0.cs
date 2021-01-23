    public class LoggingDecorator<T> : RealProxy
    {
        private readonly T _decorated;
        public LoggingDecorator(T decorated)
            : base(typeof(T))
        {
            _decorated = decorated;
        }
        public override IMessage Invoke(IMessage msg)
        {
             // Logging action
             IMethodCallMessage methodCall = (IMethodCallMessage)msg;
             MethodInfo methodInfo = methodCall.MethodBase as MethodInfo;
            return InvokeMethod(methodInfo, methodCall);
        }
    }
