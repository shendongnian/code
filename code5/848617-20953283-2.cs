    public static class TaskExtensionMethods
    {
        public static Task ContinueWith_UsingSyncContextWorkaround(this Task task, Action<Task> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler, SynchronizationContext sc)
        {
            Action<Task> actionWithWorkaround = t =>
            {
                SynchronizationContext.SetSynchronizationContext(sc);
                continuationAction(t);
            };
            return task.ContinueWith(actionWithWorkaround, cancellationToken, continuationOptions, scheduler);
        }
        public static Task StartNew_UsingSyncContextWorkaround(this TaskFactory taskFactory, Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler, SynchronizationContext sc)
        {
            Action actionWithWorkaround = () =>
            {
                SynchronizationContext.SetSynchronizationContext(sc);
                action();
            };
            return taskFactory.StartNew(actionWithWorkaround, cancellationToken, creationOptions, scheduler);
        }
    }
