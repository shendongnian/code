    private void DownloadRpdBgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        while (true)
        {
            worker.ReportProgress(1);
            if (!controller.DownloadServerData())
            {
                worker.ReportProgress(2);
            }
            else
            {
                //data download succesful
                worker.ReportProgress(3);
            }
                System.Threading.Thread.Sleep(3000); //poll every 3 secs
        }
    }
    private void DownloadRpdBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        switch(e.ProgressPercentage){
            case 1: SetStatus("Trying to fetch new data.."); break;
            case 2: SetStatus("Error communicating with the server"); break;
            case 3: SetStatus("Data downloaded!"); break;
        }
    }
