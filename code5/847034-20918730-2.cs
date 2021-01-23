    async Task AsyncWork(int n, CancellationToken token)
    {
        // prepare the modal UI window
        var modalUI = new Window();
        modalUI.Width = 300; modalUI.Height = 200;
        modalUI.Content = new TextBox();
    
        Task modalUITask = null;
    
        try
        {
            using (var client = new HttpClient())
            {
                // main loop
                for (var i = 0; i < n; i++)
                {
                    token.ThrowIfCancellationRequested();
    
                    // do the next step of async process
                    var data = await client.GetStringAsync("http://www.bing.com/search?q=item" + i);
    
                    // update the main window status
                    var info = "#" + i + ", size: " + data.Length + Environment.NewLine;
                    ((TextBox)this.Content).AppendText(info);
    
                    // show the modal UI if the data size is more than 42000 bytes (for example)
                    if (data.Length < 42000)
                    {
                        if (modalUITask == null)
                        {
                            // invoke modalUI.ShowDialog() asynchronously
                            modalUITask = Task.Factory.StartNew(
                                () => modalUI.ShowDialog(),
                                token,
                                TaskCreationOptions.None,
                                TaskScheduler.FromCurrentSynchronizationContext());
    
                            // continue after modalUI.Loaded event 
                            var modalUIReadyTcs = new TaskCompletionSource<bool>();
                            using (token.Register(() => 
                                modalUIReadyTcs.TrySetCanceled(), useSynchronizationContext: true))
                            {
                                modalUI.Loaded += (s, e) =>
                                    modalUIReadyTcs.TrySetResult(true);
                                await modalUIReadyTcs.Task;
                            }
                        }
                    }
    
                    // update modal window status, if visible
                    if (modalUI.IsVisible)
                        ((TextBox)modalUI.Content).AppendText(info);
                }
            }
    
            // wait for the user to close the dialog (if open)
            if (modalUITask != null)
                await modalUITask;
        }
        finally
        {
            // always close the window
            modalUI.Close();
        }
    }
