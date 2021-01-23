    public void AddRange(IEnumerable<T> rangeItems)
    {
        foreach (var item in rangeItems)
        {
             Items.Add(item);
        }
                base.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
                base.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                var arg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, rangeItems);
                OnCollectionChanged(arg);
    }
