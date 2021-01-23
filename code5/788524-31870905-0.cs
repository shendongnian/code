    private void OnSaveConnection(object sender)
    {
        Mouse.OverrideCursor = Cursors.Wait;
        var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        Task.Factory.StartNew(() =>
                              {
                                  if (IsServerConnected(_entityBuilder.ToString()))
                                  {
                                       OnClosingRequest();      
                                  }
                                  else
                                  {
                                      MessageBox.Show("Cannot establish connection with server " , Properties.Resources.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                                  }
                              }).ContinueWith(_ => {Mouse.OverrideCursor = Cursors.Arrow;}, uiScheduler);
        }
