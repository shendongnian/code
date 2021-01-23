    public class CanceledActivity : NativeActivity
    {
        private readonly TerminateWorkflow terminateWorkflow = new TerminateWorkflow
            {
                Reason = "Reason why I'm terminating!"
            };
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddImplementationChild(terminateWorkflow);
        }
        protected override void Execute(NativeActivityContext context)
        {
            context.ScheduleActivity(terminateWorkflow);
        }
    }
