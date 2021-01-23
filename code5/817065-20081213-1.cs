    [Serializable]
    public class Aspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            args.ReturnValue=-100;
            args.FlowBehaviour=FlowBehavior.Return;
        }
    }
    
    [Serializable]
    public class Aspect2 : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Return value = {0}", args.ReturnValue);
            // remaining code
        }
    }
    [Aspect2(AspectPriority = 1)]
    [Aspect(AspectPriority = 2)]
    public int GetMeVal()
    {
        // ...
    }
