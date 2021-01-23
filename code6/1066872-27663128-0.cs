    [Serializable]
    public class PrintAndIgnoreExceptionAttribute : OnExceptionAspect
    {
    
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine(args.Exception.Message);
            args.FlowBehavior = FlowBehavior.Return;
        }
    }
