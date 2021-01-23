        private void scrollviewer_Messages_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;
            //if (e.ExtentHeightChange != 0 && Math.Abs(sv.VerticalOffset - sv.ScrollableHeight) < 20)
            if(sv.ScrollableHeight - sv.VerticalOffset < 20)
            {
                sv.ScrollToEnd();
            }
        }
