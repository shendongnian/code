    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
        {
            if (NavigationContext.QueryString.TryGetValue("Source", out status))
            {
                MainPivot.SelectedItem = AlarmPivotItem;
                //App.MainViewModel.StartAlarm();
                //or
                //get the number from source/status...
                App.MainViewModel.CallNumber(12345);
            }
        }
    }
