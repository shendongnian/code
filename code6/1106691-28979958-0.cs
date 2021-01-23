    public class TestBackgroundWorker
    {
        private Task _task;
        private CancellationTokenSource _cancelSource;
        public CancellationToken CancellationToken
        {
            get { return _cancelSource != null ? _cancelSource.Token : null; }
        }
        ProgressIndicator progressIndicator;
    
        public readonly Action<TestBackgroundWorker> currentFunctionToExecute;
    
        private string message;
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionNameToExecute">specifies function name to be executed in background</param>
        /// <param name="isCancellable">Flag which specifies whether the operation is cancellable or not</param>
        /// <param name="functionNameWhichGetsResult">Specifies call back function to be executed after the completion of operation</param>
        public MCSBackgroundWorker(Action<TestBackgroundWorker> functionNameToExecute, bool isCancellable, string messageToDisplay)
        {
            currentFunctionToExecute = functionNameToExecute;
            _cancelSource = isCancellable ? new CancellationTokenSource() : null;
            message = messageToDisplay;
        }
    
        public void cancelBackgroundOperation()
        {
            if (_cancelSource != null)
            {
                _cancelSource.Cancel();
            }
        }
    
        public async Task Start()
        {
            activateProgressIndicator();
            _task = Task.Run(() => currentFunctionToExecute(this));
            await _task;
            _task = null;
            deactivateProgressIndicator();
        }
    
        void activateProgressIndicator()
        {
            // In theory, you should not need to use Dispatcher here with async/await.
            // But without a complete code example, it's impossible for me to
            // say for sure, so I've left it as-is.
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                var currentPage = App.RootFrame.Content as PhoneApplicationPage;
                SystemTray.SetIsVisible(currentPage, true);
                SystemTray.SetOpacity(currentPage, 0.5);
                SystemTray.SetBackgroundColor(currentPage, Colors.White);
                SystemTray.SetForegroundColor(currentPage, Colors.Black);
    
                progressIndicator = new ProgressIndicator();
                progressIndicator.IsVisible = true;
                progressIndicator.IsIndeterminate = true;
                progressIndicator.Text = message;
    
                SystemTray.SetProgressIndicator(currentPage, progressIndicator);
            });
        }
    
        void deactivateProgressIndicator()
        {
            // Likewise.
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (progressIndicator != null)
                {
                    var currentPage = App.RootFrame.Content as PhoneApplicationPage;
                    progressIndicator.IsVisible = false;
                    SystemTray.SetIsVisible(currentPage, false);
                }
            });
        }
    
        public bool isBackgroundWorkerBusy()
        {
            return _task != null;
        }
    }
