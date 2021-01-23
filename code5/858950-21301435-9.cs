    // UI Thread
    
    // prepare the message window
    var window = new Window 
    { 
        Content = new TextBlock { Text = "Wait while I'm doing the work..." },
        Width = 200,
        Height = 100
    };
    
    // run the worker
    var dispatcher = Dispatcher.CurrentDispatcher;
    var worker = new BackgroundWorker();
    
    worker.DoWork += (s, e) =>
    {
        // do the work 
        Thread.Sleep(1000);
    
        // update the UI
        dispatcher.BeginInvoke(new Action(() =>
        {
            throw new ApplicationException("Catch me if you can!");
        }));
    
        // do more work
        Thread.Sleep(1000);
    };
    
    worker.RunWorkerCompleted += (s, e) =>
    {
        // e.Error will be null
        if (e.Error != null)
            MessageBox.Show("Error: " + e.Error.Message);
        // close the message window
        window.Close();
    };
    
    // start the worker
    worker.RunWorkerAsync();
    
    // show the modal message window 
    // while the worker is working
    window.ShowDialog();
