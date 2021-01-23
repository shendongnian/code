    private void OnItemRealized(object sender, ItemRealizationEventArgs e)
    {
        var longListSelector = sender as LongListSelector;
        if (longListSelector == null)
        {
            return;
        }
 
        var item = e.Container.Content;
        var items = longListSelector.ItemsSource;
        var index = items.IndexOf(item);
 
        if (items.Count - index <= 1)
        {
            //ask for more items and add theme here
        }
    }
