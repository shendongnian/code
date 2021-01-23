    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Sender will always be your TabControl.
        // So, just check if OriginalSource is same as sender (TabControl).
        if (e.OriginalSource == sender)
        {
            // Put your code here.
        }
    }
