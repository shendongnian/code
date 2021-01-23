    public static void SortListControl(ListControl control, bool isAscending)
    {
        List<ListItem> collection;
    
        if (isAscending)
            collection = control.Items.Cast<ListItem>()
                .Select(x => new ListItem {Text = x.Text, Value = x.Value})
                .OrderBy(c => c.Text)
                .ToList();
        else
            collection = control.Items.Cast<ListItem>()
                .Select(x => new ListItem {Text = x.Text, Value = x.Value})
                .OrderByDescending(c => c.Text).
                ToList();
    
        control.Items.Clear();
    
        foreach (ListItem item in collection)
            control.Items.Add(new ListItem {Text = item.Text, Value = item.Value});
    }
