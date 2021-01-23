    private void HandleMergeOffset(DynamicGridItem item, int offset)
    {
        var otherItem = FindItemByXOffset(item, offset);
        if (otherItem == null)
        {
           return; // Nothing to do
        }
        otherItem.Merge -= HandleMerge;
        otherItem.Split -= HandleSplit;
        Grid.SetColumnSpan(item, Grid.GetColumnSpan(item) + Grid.GetColumnSpan(otherItem));
        grid.Children.Remove(otherItem);
        if (offset < 0) // Reposition item if merging left
        {
            Grid.SetColumn(item, otherItem.X);
            item.X = otherItem.X;
        }
    }
