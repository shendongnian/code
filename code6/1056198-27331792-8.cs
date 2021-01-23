        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_worker == null)
            {
                _worker = new AbortableBackgroundWorker();
                _worker.WorkerReportsProgress = true;
                _worker.WorkerSupportsCancellation = true;
                _worker.DoWork += _worker_DoWork;
                _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            }
            if (!_worker.IsBusy)
                _worker.RunWorkerAsync();
        }
