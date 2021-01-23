    public abstract class Job<TResult> where TResult : JobResult
    {
        public abstract TResult Run();
    }
    
    public class Job1 : Job<Job1Result>
    {
        public override Job1Result Run()
        {
             //
        }
    }
