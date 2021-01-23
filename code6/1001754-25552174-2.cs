    private void sortListBoxItems(ref ListBox lb, bool ascending)
    {
        List<object> items;
        items = lb.Items.OfType<object>().ToList();
        lb.Items.Clear();
        if (ascending)
        { lb.Items.AddRange(items.OrderBy(i => i).ToArray()); }
        else
        { lb.Items.AddRange(items.OrderByDescending(i => i).ToArray()); }
    }
