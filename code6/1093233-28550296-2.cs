    private void HandleSplit(object sender, EventArgs e)
    {
        var item = (DynamicGridItem)sender;
        var itemColSpan = Grid.GetColumnSpan(item);
        if (itemColSpan < 2)
        {
            return; // Nothing to do
        }
        var newItem = new DynamicGridItem(item.X, item.Y);
        newItem.Merge += HandleMerge;
        newItem.Split += HandleSplit;
        grid.Children.Add(newItem);
        Grid.SetColumn(newItem, newItem.X);
        Grid.SetRow(newItem, newItem.Y);
        Grid.SetColumn(item, item.X + 1);
        Grid.SetColumnSpan(item, itemColSpan - 1);
        item.X += 1;
    }
