    public class ThrownActivityException : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> ActivityDisplayName { get; set; }
        public override void Execute(CodeActivityContext context)
        {
            var displayName = ActivityDisplayName.Get(context);
            throw new ActivityException(displayName);
        }
    }
