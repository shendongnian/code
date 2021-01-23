    public class LogAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Entering [ {0} ] ...", args.Method);
            base.OnEntry(args);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Leaving [ {0} ] ...", args.Method);
            base.OnExit(args);
        }
    }
