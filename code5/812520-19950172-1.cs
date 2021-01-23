    private void SearchInDatabase()
    {
        if (worker.IsBusy)
            worker.CancelAsync();
        while(worker.IsBusy)
            System.Threading.Thread.Sleep(100);
    
        worker.RunWorkerAsync();
    }
