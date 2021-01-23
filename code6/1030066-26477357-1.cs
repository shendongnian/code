    private void SettingsHub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var itemId = (e.AddedItems[0] as ListViewItem).Name;
            }            
        }
