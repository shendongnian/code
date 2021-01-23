    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        var control = sender as UserControl;
        if (control != null)
        {
            Style s = control.Resources["test"] as Style;
            testControl.Style = s;
            // control.ApplyTemplate(); // it's not necessary in your case
        }            
    }
