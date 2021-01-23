        public delegate void AsyncMethodCaller(CancellationToken ct);
        private CancellationTokenSource _cts;
        private AsyncMethodCaller caller;
        private IAsyncResult methodResult;
        // Form Load event
        private void MainForm_Load(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            caller = new AsyncMethodCaller(DoWorkAsync);
            methodResult = caller.BeginInvoke(_cts.Token,
                ar =>
                {
                },
                null);
        }
        // Form Closing event
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts.Cancel();          
            MessageBox.Show("Task cancellation requested");    
        }
        // async work
        private void DoWorkAsync(CancellationToken ct)
        {
            var i = 0;
            while (true)
            {
                var item = i++;
                Debug.Print("Starting work item " + item);
                // use Sleep as a mock for some atomic operation which cannot be cancelled
                Thread.Sleep(10000);
                Debug.Print("Finished work item " + item);
                if (ct.IsCancellationRequested)
                {
                    return;
                }
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            methodResult.AsyncWaitHandle.WaitOne();
            MessageBox.Show("Task cancelled");
        }
