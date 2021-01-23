    class DoWorkTester
    {
        int currentIndex = 0;
        GridRow[] rows;
    
    
        public void ExecuteWorkers()
        {
    
            GridRow rowA = new GridRow
            {
                PropertyA = "abc",
                PropertyB = "def"
            };
    
            GridRow rowB = new GridRow
            {
                PropertyA = "123",
                PropertyB = "456"
            };
    
            GridRow rowC = new GridRow
            {
                PropertyA = "xyz",
                PropertyB = "789"
            };
    
            rows = new GridRow[] { rowA, rowB, rowC };
    
            currentIndex = 0;
    
            runWorkers();
        }
    
        BackgroundWorker worker;
    
        void runWorkers()
        {
            //done all rows
            if (currentIndex >= rows.Length - 1)
                return;
    
            //is the worker busy?
            if (worker != null && worker.IsBusy)
            {
                //TODO: Trying to execute on a running worker.
                return;
            }
    
            //create a new worker
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += (o, e) =>
            {
                //TODO: Update the UI that the progress has changed
            };
            worker.DoWork += (o, e) =>
            {
                if (currentIndex >= rows.Length - 1)
                {
                    //indicate done
                    e.Result = new WorkResult
                    {
                        Message = "",
                        Status = WorkerResultStatus.DONE
                    };
                    return;
                }
                //check if the worker is cancelling
                else if (worker.CancellationPending)
                {
                    e.Result = WorkResult.Cancelled;
                    return;
                }
                currentIndex++;
    
                //report the progress to the UI thread.
                worker.ReportProgress(currentIndex);
    
                //TODO: Execute your logic.
                if (worker.CancellationPending)
                {
                    e.Result = WorkResult.Cancelled;
                    return;
                }
    
                e.Result = WorkResult.Completed;
            };
            worker.RunWorkerCompleted += (o, e) =>
            {
                var result = e.Result as WorkResult;
                if (result == null || result.Status != WorkerResultStatus.DONE)
                {
                    //TODO: Code for cancelled  \ failed results
                    worker.Dispose();
                    worker = null;
                    return;
                }
                //Re-call the run workers thread
                runWorkers();
            };
            worker.RunWorkerAsync(rows[currentIndex]);
        }
    
        /// <summary>
        /// cancel the worker
        /// </summary>
        void cancelWorker()
        {
            //is the worker set to an instance and is it busy?
            if (worker != null && worker.IsBusy)
                worker.CancelAsync();
    
        }
    }
    
    enum WorkerResultStatus
    {
        DONE,
        CANCELLED,
        FAILED
    }
    
    class WorkResult
    {
        public string Message { get; set; }
        public WorkerResultStatus Status { get; set; }
    
        public static WorkResult Completed
        {
            get
            {
                return new WorkResult
                {
                    Status = WorkerResultStatus.DONE,
                    Message = ""
                };
            }
        }
    
        public static WorkResult Cancelled
        {
            get
            {
                return new WorkResult
                {
                    Message = "Cancelled by user",
                    Status = WorkerResultStatus.CANCELLED
                };
            }
        }
    }
    
    
    class GridRow
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
    }
