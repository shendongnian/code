    public class MyJobAttribute : JobFilterAttribute, IServerFilter
    {
        public void OnPerformed(PerformedContext performedContext)
        {
            //here you'll be called on the same thread of the job after it has been executed
        }
        public void OnPerforming(PerformingContext performingContext)
        {
            //here you'll be called on the same thread of the job that will be executed
        }
    }
