    MessageBoxResult result = Confirm("Are you sure you want to Close?","Close Application");
    if (result == MessageBoxResult.Yes)
    {
      Application.Exit();
    }
   
    private static MessageBoxResult Confirm(string message, string caption)
    {
            return MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No);
    }
