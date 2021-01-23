    // just a default sync context
    private readonly SynchronizationContext _defaultContext = new SynchronizationContext();
    void ReceiverRun()
    {
        while (true)    // <-- i would replace this with a cancellation token
        {
            var msg = ReadNextMessage();
            TaskWithContext<TResult> task = requests[msg.RequestID];
            // if it wasn't a winforms/wpf thread, it would be null
            // we choose our default context (threadpool)
            var context = task.Context ?? _defaultContext;
            // execute it on the context which was captured where it was added. So it won't get completed on this thread.
            context.Post(state =>
            {
                if (msg.Error == null)
                    task.TaskCompletionSource.SetResult(msg);
                else
                    task.TaskCompletionSource.SetException(new Exception(msg.Error));
            });
        }
    }
    public static Task<Response> SendAwaitResponse(string msg)
    {
        // The key is here! Save the current synchronization context.
        var t = new TaskWithContext<Response>(SynchronizationContext.Current); 
          
        requests.Add(GetID(msg), t);
        stream.Write(msg);
        return t.TaskCompletionSource.Task;
    }
    // class to hold a task and context
    public class TaskWithContext<TResult>
    {
        public SynchronizationContext Context { get; }
        public TaskCompletionSource<TResult> TaskCompletionSource { get; } = new TaskCompletionSource<Response>();
        public TaskWithContext(SynchronizationContext context)
        {
            Context = context;
        }
    }
