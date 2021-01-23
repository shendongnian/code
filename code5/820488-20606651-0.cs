    public class AsyncCommand : ICommand, IDisposable
    {
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker {WorkerSupportsCancellation = true};
        private readonly Func<bool> _canExecute;
        public AsyncCommand(Action action, Func<bool> canExecute = null, Action<object> completed = null,
                            Action<Exception> error = null)
        {
            _backgroundWorker.DoWork += (s, e) =>
                {
                    CommandManager.InvalidateRequerySuggested();
                    action();
                };
            _backgroundWorker.RunWorkerCompleted += (s, e) =>
                {
                    if (completed != null && e.Error == null)
                        completed(e.Result);
                    if (error != null && e.Error != null)
                        error(e.Error);
                    CommandManager.InvalidateRequerySuggested();
                };
            _canExecute = canExecute;
        }
        public void Cancel()
        {
            if (_backgroundWorker.IsBusy)
                _backgroundWorker.CancelAsync();
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null
                       ? !_backgroundWorker.IsBusy
                       : !_backgroundWorker.IsBusy && _canExecute();
        }
        public void Execute(object parameter)
        {
            _backgroundWorker.RunWorkerAsync();
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_backgroundWorker != null)
                    _backgroundWorker.Dispose();
            }
        }
    }
