    public static class TaskExtensions
    {
        private static bool IsAspNetContext(this SynchronizationContext context)
        {
            //Maybe not the best way to detect the AspNetSynchronizationContext but it works for now
            return context != null && context.GetType().FullName == "System.Web.AspNetSynchronizationContext";
        }
        /// <summary>
        /// A version of ContinueWith that does some extra gynastics when running under the ASP.NET Synchronization 
        /// Context in order to avoid deadlocks.  The <see cref="continuationFunction"/> will always be run on the 
        /// current SynchronizationContext so:
        /// Before:  task.ContinueWith(t => { ... }, TaskScheduler.FromCurrentSynchronizationContext());
        /// After:   task.SafeContinueWith(t => { ... });
        /// </summary>
        public static Task<T> SafeContinueWith<T>(this Task task, Func<Task,T> continuationFunction)
        {
            //Grab the context
            var context = SynchronizationContext.Current;
            //If we aren't in the ASP.NET world, we can defer to the standard ContinueWith
            if (!context.IsAspNetContext())
            {
                return task.ContinueWith(continuationFunction, TaskScheduler.FromCurrentSynchronizationContext());
            }
            //Otherwise, we need our continuation to be run on a background thread and then synchronously evaluate
            //  the continuation function in the captured context to arive at the resulting value
            return task.ContinueWith(t =>
            {
                var result = default(T);
                context.Send(_ => result = continuationFunction(t), null);
                //TODO: Verify that Send really did complete synchronously?  I think it's required to by Contract?
                //      But I'm not sure I'd want to trust that if I end up using this in producion code.
                return result;
            });
        }
        //Same as above but for non-generic Task input so a bit simpler
        public static Task SafeContinueWith(this Task task, Action<Task> continuation)
        {
            var context = SynchronizationContext.Current;
            if (!context.IsAspNetContext())
            {
                return task.ContinueWith(continuation, TaskScheduler.FromCurrentSynchronizationContext());
            }
            return task.ContinueWith(t => context.Send(_ => continuation(t), null));
        }
    }
