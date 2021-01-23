    public void AddRange(IEnumerable<PersonName> items) {
        var addedItems = items.ToList();
            
        foreach (var i in addedItems) 
            Items.Add(i);
        OnCollectionChanged(
            new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add, 
                addedItems
            )
        );
    }
