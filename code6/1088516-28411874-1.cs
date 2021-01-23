    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
     
        this.Dispatcher.BeginInvoke(() =>
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
     
            this.Dispatcher.BeginInvoke(() =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
     
                this.Dispatcher.BeginInvoke(() =>
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                });
            });
        });
    }
