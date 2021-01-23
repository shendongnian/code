    protected void ShortFileCreator_ReportProgress(object sender, ShortFileCreator.ProgressArgs e)
    {
        Dispatcher.Invoke((Action)delegate
        {
           //update progress bar label
           txtProgress.Content = String.Format("{0} of {1} Records Processed", e.TotalProcessed, e.TotalRecords);
           //update progress bar value
           progress.Value = (double) e.TotalProcessed/e.TotalRecords;
        });
    }
