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
                this.DialogResult = true;
            }));
                
        });
    }
