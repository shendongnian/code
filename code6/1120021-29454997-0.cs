    public class InvokingProxy : RealProxy
        {
            private readonly INamedPipe _namedPipe;
    
            InvokingProxy(object i_Target, INamedPipe i_NamedPipe) : base(i_Target.GetType())
            {
                _namedPipe = i_NamedPipe;
            }
    
            public override IMessage Invoke(IMessage i_Msg)
            {
                var methodCall = i_Msg as IMethodCallMessage;
    
                if (methodCall != null)
                {
                    return HandleMethodCall(methodCall);
                }
    
                return null;
            }
    
            IMessage HandleMethodCall(IMethodCallMessage i_MethodCall)
            {
                _namedPipe.PushMessage(new PipeMessageArgs(i_MethodCall.MethodName, i_MethodCall.InArgs));
                return new ReturnMessage(null, null, 0, i_MethodCall.LogicalCallContext, i_MethodCall);
            }
    
            public static T Wrap<T>(T i_Target, INamedPipe i_NamedPipe) where T : MarshalByRefObject
            {
                return (T)new InvokingProxy(i_Target, i_NamedPipe).GetTransparentProxy();
            }
        }
