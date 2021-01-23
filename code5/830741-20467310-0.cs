    Process  _childApp;
    private void SpawnProcess()
    {
    ...
        if (_MyPath != "")
        {
           _childApp= new Process();
           string str = @_MyPath;
           _childApp.StartInfo.FileName = str;
           _childApp.Start();
        }
        else
        {
           MessageBox.Show("Path Empty", "Error", MessageBoxButton.OK,
                                                  MessageBoxImage.Error);
        }
    ...
    }
    private void StopProcess()
    {
        if (_childApp.HasExited)
            return;
        try
        {
            _childApp.Kill();
            if (!_childApp.WaitForExit(5000))
            {
              MessageBox.Show("Closing the app takes too long","Warning",
                                                  MessageBoxButton.OK,
                                                  MessageBoxImage.Error);
            }
        }
        catch(Exception exc)
        {
              MessageBox.Show(exc.ToString(),"Failed to close app",
                                                  MessageBoxButton.OK,
                                                  MessageBoxImage.Error);
        }
    }
