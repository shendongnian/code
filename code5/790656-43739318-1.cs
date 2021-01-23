    ProgressDialog progress = new ProgressDialog(this);
    progress.Indeterminate = true;
    progress.SetProgressStyle(ProgressDialogStyle.Spinner);
    progress.SetMessage("Loading... Please wait...");
    progress.SetCancelable(false);
    
    RunOnUiThread(() =>
    {
        progress.Show();
    });
    Task.Run(()=>
    //here savedata method
    ).ContinueWith(Result=>RunOnUiThread(()=>progress.Hide()));
