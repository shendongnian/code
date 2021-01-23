    public new void Add(T item)
    {
        item.PropertyChanged += Item_PropertyChanged;
        base.Add(item);
    }
...
    public new bool Remove(T item)
    {
        if (item == null) return false;
        item.PropertyChanged -= Item_PropertyChanged;
        return base.Remove(item);
    }
