    private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var listView = sender as ListView;
            if (!(sender is ListView))
            {
                return;
            }
            var hitTest = listView.HitTest(e.X, e.Y);
            ListViewItem tappedListViewItem = hitTest.Item;
        }
