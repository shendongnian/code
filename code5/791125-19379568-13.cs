    public sealed class TaskCompletionNotifier<TResult> : INotifyPropertyChanged
    {
        public TaskCompletionNotifier(Task<TResult> task)
        {
            Task = task;
            if (task.IsCompleted) return;
            task.ContinueWith(t =>
            {
                var temp = PropertyChanged;
                if (temp != null)
                {
                    temp(this, new PropertyChangedEventArgs("Result"));
                }
            }); 
        }
        // Gets the task being watched. This property never changes and is never <c>null</c>.
        public Task<TResult> Task { get; private set; }
        // Gets the result of the task. Returns the default value of TResult if the task has not completed successfully.
        public TResult Result { get { return (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult); } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
