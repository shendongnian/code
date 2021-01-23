    class YourActivity : NativeActivity
    {
        protected override void Execute(NativeActivityContext context)
        {
            ConvertWorkspaceItem it = new ConvertWorkspaceItem();
            context.ScheduleActivity(it);
        }
    }
