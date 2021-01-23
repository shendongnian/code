    private static void scrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        var scrollViewer = sender as ScrollViewer;
        if (scrollViewer != null)
        {
            // Here we determine if the end reached
            if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
            {
                command = GetCommand(listBox);
                // Execute the command
                command.Execute(listBox);
            }
        }
    }
