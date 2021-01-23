    private void OnSelectedItemChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs e)
    {
        ((YourViewModel)this.DataContext).NewSelectedItemMethodOrWhateverYouWant(this.YourLongListSelectorName.SelectedItem);
        //or
        ((YourViewModel)this.DataContext).SelectedItem = this.YourLongListSelectorName.SelectedItem;
    }
