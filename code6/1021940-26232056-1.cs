       private void businessFilterString_TextChanged(object sender, TextChangedEventArgs e)
    {
        sI.ItemsSource = businesses.Collection.Where(b => b.name.ToUpper().Contains(searchBox.Text.ToUpper()) || b.address.ToUpper().Contains(searchBox.Text.ToUpper())).ToList();
        LayoutUpdateFlag = true;
    }
