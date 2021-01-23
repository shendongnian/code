    private void OnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        // If scrollviewer is scrolled up
        if (_scrollViewer.VerticalOffset < 150)
        {
            // Start loading new items...
        }
    }
