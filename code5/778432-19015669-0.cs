    public void AddRange(IEnumerable<T> rangeItems)
    {
        foreach (var item in rangeItems)
        {
             Items.Add(item);
        }
        base.OnPropertyChanged("Count");
        base.OnPropertyChanged("Item[]");
        var arg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItems);
        OnCollectionChanged(arg);    
    }
