    private void SomeMethod()
    {
       Task.Factory.StartNew(() =>
			{
                           /// do all your logic here
                           //Update Text on the UI thread 
                           Application.Current.Dispatcher.BeginInvoke( DispatcherPriority.Input,
                          new Action(() => { statusTextBox.Text = "newValue";}));
                           //continue with the rest of the logic that take a long time
                        });
