    try
    {
        await Task.Factory.StartNew(() =>
        {
            WarningWindow window = new WarningWindow(
                ProcessControl.Properties.Settings.Default.WarningHeader,
                ProcessControl.Properties.Settings.Default.WarningMessage,
                processName,
                ProcessControl.Properties.Settings.Default.WarningFooter,
                ProcessControl.Properties.Settings.Default.WarningTimeout * 1000);
            window.ShowDialog();
        
        }, CancellationToken.None, TaskCreationOptions.None, this.taskScheduler);
    
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message)
    }
