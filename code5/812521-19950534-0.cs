    void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
    {
        // .. cut ..
        // disable the calendar and go on
        calendar.IsEnabled = false;
        SearchInDatabase();
    }
    private void SearchInDatabase()
    {
        // No longer needed: selection processing is now "atomic"
        // if (worker.IsBusy) worker.CancelAsync();
        worker.RunWorkerAsync();
    }
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // .. cut ..
        calendar.IsEnabled = true;        
    }
