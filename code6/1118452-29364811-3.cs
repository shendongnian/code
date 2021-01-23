    private bool _closeAuthorised = false;
    public WorkInProgressDialog()
    {
        InitializeComponent();
        
        WorkProgressBar.Maximum = 10;
        WorkProgressBar.Minimum = 0;
        Task.Factory.StartNew(() =>
        {
            // Do whatever processing you need to here
            for (int i = 0; i < 10; i++)
            {
                // Any updates to the UI need to be done on the UI thread
                this.Dispatcher.Invoke((Action)(() =>
                {
                    WorkProgressBar.Value = i;
                }));
                                        
                Thread.Sleep(1000);
            }
            // Set the DialogResult and hence close, also on the UI thread
            this.Dispatcher.Invoke((Action)(() =>
            {
                _closeAuthorised = true;
                this.DialogResult = true;
            }));
                
        });
    }
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        // If the user uses ALT+F4 to try andclose the loading dialog, this will cancel it
        if (!_closeAuthorised)
            e.Cancel = true;
        base.OnClosing(e);
    }
