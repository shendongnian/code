    public class CacheThisMethod : OnMethodBoundaryAspect
    {
            public override void OnEntry(MethodExecutionArgs args)
            {
               if (isCached( args.Method.name)
                   {
                    args.MethodExecutionTag =  getReturnValue(args.Method.name)
                    OnExit(args);
                   }
               else
                   {
                    //continue
                   }
            }
            public override void OnExit(MethodExecutionArgs args)
            {
               //args.Method.ReturnValue = args.MethodExecutionTag;
                args.ReturnValue = args.MethodExecutionTag;
                args.FlowBehavior = FlowBehavior.Return;
            }
    }
