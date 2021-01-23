    void ReloadListBox()
    {
       listBox.BeginUpdate(); // Suspend redrawing
       listBox.Items.Clear(); // Remove all existing items first
       backgroundWorker.RunWorkerAsync(); // Asynchronous generate new items
    }
    
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       // Report a new list item in e.UserState.
       var newItem = e.UserState;
       listBox.Items.Add(newItem);
    }
    
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
       // Alternatively, return a list of items in e.Result.
       var items = e.Result;
       listBox.Items.AddRange(items);
       listBox.EndUpdate(); // Resume redrawing and update
    }
