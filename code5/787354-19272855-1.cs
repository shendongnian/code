    public class CanceledActivity : NativeActivity
    {
        protected override void Execute(NativeActivityContext context)
        {
            throw new Exception("this will not gracefully terminate the workflow")
        }
    }
