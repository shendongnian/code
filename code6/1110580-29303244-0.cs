    [Serializable]
    public class TestAspect : OnMethodBoundaryAspect
    {
        private const string Name = "LogId";
        public TestAspect()
        {
            this.ApplyToStateMachine = true;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            object contextId = CallContext.LogicalGetData(Name);
            if (contextId == null)
            {
                contextId = Guid.NewGuid().ToString();
                CallContext.LogicalSetData(Name, contextId);
            }
            // Build the log message and send the output to the underlying framework
            Console.WriteLine("{0}: {1}", contextId, args.Method.Name);
        }
    }
