    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var list = new List<int>();
            for (int i = 0; i < 100; ++i)
            {
                list.Add(i);
            }
            ItemsControl1.ItemsSource = list;
            ItemsControl2.ItemsSource = list;
        }
        private void ScrollViewer1_OnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (ScrollViewer1.VerticalOffset != ScrollViewer2.VerticalOffset)
            {
                ScrollViewer2.ScrollToVerticalOffset(ScrollViewer1.VerticalOffset);
            }
        }
        private void ScrollViewer2_OnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (ScrollViewer1.VerticalOffset != ScrollViewer2.VerticalOffset)
            {
                ScrollViewer1.ScrollToVerticalOffset(ScrollViewer2.VerticalOffset);
            }
        }
