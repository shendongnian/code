    ProgressBar ProgressBar1 = new ProgressBar();
    ProgressBar1.Maximum = 100;
    ProgressBar1.Minimum = 0;
    Task.Start();
    if( Task.Status == "Running")
    {
        ProgressBar1.Value = 50;
    }
    if( Task.Status == "completed")
    {
        ProgressBar1.Value =100;
    }
    else 
    {
        ProgressBar.Value=0;
        Task.Wait();
    }
