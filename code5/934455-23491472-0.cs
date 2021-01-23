    [Serializable]
    public class MyValidationAttribute : OnMethodBoundaryAspect
    {
        public MyValidationAttribute()
        {
            this.ApplyToStateMachine = false;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (invalid)
            {
                args.ReturnValue = Task.FromResult("blah");
                args.FlowBehavior = FlowBehavior.Return;
            }
        }
    }
    public class MyClass
    {
        [MyValidation]
        public async Task<string> DoIt()
        {
            // ...
        }
    }
