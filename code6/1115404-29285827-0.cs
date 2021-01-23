    [Serializable]
    public class MyAspect : OnExceptionAspect
    {
        public MyAspect()
        {
            this.ApplyToStateMachine = true;
        }
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("OnException({0});", args.Exception.Message);
        }
    }
