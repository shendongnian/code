    OnNavigatedTo(NavigationEventArgs e) {
        ...
        GetItems(itemGridView.ItemsSource, NavigationParameter);
        ...
    }
    private void GetItems(CollectionViewSource source, string key) {
        var items = new List<Item> 
        {
            new Item { Category = "blah", Title = "something" },
            ...
        };
        var itemsByCategories = unsortedItems.GroupBy(x => x.Category)
            .Select(x => new ItemCategory { Title = x.Key, Items = x.ToList() });
    
        source.Source = itemsByCategories.ToList();
        source.IsSourceGrouped = true;
        source.ItemsPath = new PropertyPath("Items");
    }
