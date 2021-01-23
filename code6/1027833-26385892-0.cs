    public static void RunOnce(Action action, ref RunOnceToken token)
    {
        if (token == null || token.IsCompleted)
        {
            token = new RunOnceToken(
                Application.Current.Dispatcher.BeginInvoke(
                    action,
                    DispatcherPriority.Background));
        }
    }
    public sealed class RunOnceToken : IDisposable
    {
        private DispatcherOperation _operation;
        public RunOnceToken(DispatcherOperation operation)
        {
            if (operation != null &&
                operation.Status != DispatcherOperationStatus.Completed &&
                operation.Status != DispatcherOperationStatus.Aborted)
            {
                _operation = operation;
                _operation.Completed += OnCompletedOrAborted;
                _operation.Aborted += OnCompletedOrAborted;
            }
        }
        private void OnCompletedOrAborted(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public bool IsCompleted
        {
            get { return _operation == null; }
        }
        public void Dispose()
        {
            var operation = _operation;
            if (operation == null)
                return;
            _operation = null;
            operation.Completed -= OnCompletedOrAborted;
            operation.Aborted -= OnCompletedOrAborted;
        }
    }
