    var applicationBars = new List<Microsoft.Phone.Shell.ApplicationBar>();
    private void MainPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (mainPivot.SelectedIndex)
        {
            case 0: ApplicationBar = applicationBars[0]; break;
            case 1: ApplicationBar = applicationBars[1]; break;
            case 2: ApplicationBar = applicationBars[2]; break;
            ...
        }
    }
