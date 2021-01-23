    public void DoScroll(ScrollChangedEventArgs e)
        {
            var scrollViewer = e.OriginalSource as ScrollViewer;
            if (scrollViewer != null && // Do we have a scroll bar?
                scrollViewer.ScrollableHeight > 0 && // Avoid firing the event on an empty list.
                scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight && // Are we at the end of the scrollbar?
            {
               // Do your end-of-scroll code here...
            }
        }
