        var task = Task.Factory.StartNew(() =>
        {
            System.Windows.Threading.Dispatcher.InvokeAsync(() =>
            {
                WarningWindow window = new WarningWindow(
                    ProcessControl.Properties.Settings.Default.WarningHeader,
                    ProcessControl.Properties.Settings.Default.WarningMessage,
                    processName,
                    ProcessControl.Properties.Settings.Default.WarningFooter,
                    ProcessControl.Properties.Settings.Default.WarningTimeout * 1000);
    
                window.Closed += (s, e) =>
                    window.Dispatcher.InvokeShutdown();
                window.Show();
            });
            System.Windows.Threading.Dispatcher.Run();
        
        }, CancellationToken.None, TaskCreationOptions.None, this.taskScheduler);
