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
             // Add logging action here
             var methodCall = msg as IMethodCallMessage;
             var methodInfo = methodCall.MethodBase as MethodInfo;
             
             // Invoke actual method
             var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
             return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
        }
    }
