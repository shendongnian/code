    private void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == Windows.System.VirtualKey.Enter)
      {
        Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().CoreWindow.IsInputEnabled = false;
        Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().CoreWindow.IsInputEnabled = true;                
      }
    }
