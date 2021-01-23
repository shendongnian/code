        private void RSSItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" CALLED ITEM CHANGED ");
            //ListViewItem itemId = ((sender as ListView).SelectedItem as ListViewItem);
            int count = e.AddedItems.Count;
            string  itemStr = e.AddedItems[0].ToString();
            System.Diagnostics.Debug.WriteLine(" DOWNLOADING FEED URL : " + itemStr);
        }
