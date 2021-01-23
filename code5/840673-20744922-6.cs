    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var destinationItems = new Collection<TreeItemObject>();
        var items = values[0] as Collection<TreeItemObject>;
        var parent = values[1] as Connection;
        // null checks are required here for items and parent
        foreach (var item in items)
        {
            var destinationItem = item.Clone(); // Assumed extension method
            destinationItem.Parent = new WeakReference(parent);
            destinationItems.Add(destinationItem);
        }
        return destinationItems;
    }
