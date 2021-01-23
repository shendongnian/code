    private static bool _isConfirmed = false;
    private void Window_Closing(object sender, CancelEventArgs e)
    {
    
        if (!_isConfirmed)
        {
            MessageBoxResult result = MessageBox.Show("Please Be Sure That Input & Output Files Are Saved.  Do You Want To Close This Program?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
            _isConfirmed = true;
        }
    }
