        private void lstActivitySub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var data = e.AddedItems[0] as String;
            }
        }  
