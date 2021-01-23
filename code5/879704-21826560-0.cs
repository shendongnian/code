    public class LogEnabled : OnMethodBoundaryAspect
    {
            public override void OnEntry(MethodExecutionArgs args)
            {
                Logger.LogMethodCall();
            }
    }
