    private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
    {
       var scrollViewer = (ScrollViewer)sender;
       if (scrollViewer.VerticalOffset == 0)
              MessageBox.Show("This is the start.");
       else if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
              MessageBox.Show("This is the end"); 
    }
