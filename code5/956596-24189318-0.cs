    private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (tab1.IsSelected)
        {
            //this line is not working
            tabcontrol.SelectedIndex = 1;
            Task.Factory.StartNew(() => LongRunningMethod(parameter));
        }
    }
    private void LongRunningMethod(object parameter)
    {
        // perform long running process here
    }
