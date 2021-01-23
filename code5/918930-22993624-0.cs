    private BackgroundWorker loadData = new BackgroundWorker();
    loadData.DoWork += loadData_DoWork;
    loadData.ProgressChanged += loadData_ProgressChanged; // Only do this if you are going to report progress
    loadData.WorkerReportsProgress = true;
    loadData.WorkerSupportsCancellation = false; // You can set this to true if you provide a Cancel button
    loadData.RunWorkerCompleted += loadData_RunWorkerCompleted;
    private void DoWork( object sender, DoWorkEventArgs e ) {
        BackgroundWorker worker = sender as BackgroundWorker;
        bool done = false;
        while ( !done ) {
            // If you want to check for cancellation, include this if statement
            if ( worker.CancellationPending ) {
                e.Cancel = true;
                return;
            }
            // Your code to load the data goes here.
            // If you wish to display progress updates, compute how far along you are and call ReportProgress here.
        }
    }
    private void loadData_ProgressChanged( object sender, ProgressChangedEventArgs e ) {
        // You code to report the progress goes here.
    }
    private void loadData_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
        // Your code to do whatever is necessary to put the UI into the completed state goes here.
    }
