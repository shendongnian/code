    private void OnApplicationClosing(CancelEventArgs e)
    {
        // Ask user to save changes, e.g. In a message box 
                
        switch (result)
        {
            case MessageBoxResult.Cancel:
                e.Cancel = true;
                return;
            case MessageBoxResult.Yes:
                // Save changes
                break;
            case MessageBoxResult.No:
                break;
        }
    }
