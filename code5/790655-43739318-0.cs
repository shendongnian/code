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
    //write here savedata code
    ).ContinueWith(Result=>RunOnUiThread(()=>progress.Hide()));
