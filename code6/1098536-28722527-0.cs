    private void SelectingCoreItems(SortedList<ICoreItem, ICoreItem> sortedList)
    {
        var lookup = new HashSet<ICoreItem>(sortedList.Select(i => i.Key));
        for (int i = 0; i < VisibleCoreItems.Count; i++)
        {
            CoreItem currentItem = VisibleCoreItems[i];
            if (lookup.Contains(currentItem))
            {
                itemListView.SelectedItems.Add(currentItem);
            }
        }
    }
