    private void ExpandAllInnerItems()
    {
        GridItem root = Root;
        IList<GridItem> allItems = GetAllChildGridItems(root);
        foreach (GridItem item in allItems)
        {
            if (item.Parent != root && item.Expandable)
            {
                item.Expanded = true;
            }
            else if(item.GridItemType == GridItemType.Category)
            {
                item.Expanded = false;
            }
        }
    }
    private GridItem Root
    {
        get
        {
            GridItem aRoot = propertyGrid1.SelectedGridItem;
            do
            {
                aRoot = aRoot.Parent ?? aRoot;
            } while (aRoot.Parent != null);
            return aRoot;
        }
    }
    private IList<GridItem> GetAllChildGridItems(GridItem theParent)
    {
        List<GridItem> aGridItems = new List<GridItem>();
        foreach (GridItem aItem in theParent.GridItems)
        {
            aGridItems.Add(aItem);
            if (aItem.GridItems.Count > 0)
            {
                aGridItems.AddRange(GetAllChildGridItems(aItem));
            }
        }
        return aGridItems;
    }
