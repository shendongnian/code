    public class UITaskRunner
    {
        private readonly CoreDispatcher dispatcher;
        public UITaskRunner(CoreDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        public async Task Run(Action method)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
            await this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => TaskRunner(method, taskCompletionSource));
            await taskCompletionSource.Task;
        }
        public async Task<TResult> Run<TResult>(Func<TResult> method)
        {
            TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
            await this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => TaskRunner(method, taskCompletionSource));
            return await taskCompletionSource.Task;
        }
        private static void TaskRunner(Action method, TaskCompletionSource<object> taskCompletionSource)
        {
            method();
            taskCompletionSource.SetResult(null);
        }
        private static void TaskRunner<TResult>(Func<TResult> method, TaskCompletionSource<TResult> taskCompletionSource)
        {
            taskCompletionSource.SetResult(method());
        }
    }
