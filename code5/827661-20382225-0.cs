        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                Product p = e.AddedItems[0] as Product;
            }
        }
