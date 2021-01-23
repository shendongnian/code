        private void Tab1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Contains(AddTabButton))
            {
                //Logic for adding a new item to the bound collection goes here.
                string newItem = "Item " + (MyList.Count + 1);
                MyList.Add(newItem);
                e.Handled = true;
                Dispatcher.BeginInvoke(new Action(() => Tab1.SelectedItem = newItem));
            }
        }
