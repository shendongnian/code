    public static void SortListControl(ListControl control, bool isAscending)
    {
        List<ListItem> collection;
    
        if (isAscending)
            collection = control.Items.Cast<ListItem>()
                .Select(x => x)
                .OrderBy(x => x.Text)
                .ToList();
        else
            collection = control.Items.Cast<ListItem>()
                .Select(x => x)
                .OrderByDescending(x => x.Text)
                .ToList();
    
        control.Items.Clear();
    
        foreach (ListItem item in collection)
            control.Items.Add(item);
    }
