    event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
    {
        add {
                CollectionChanged += value;
        }
        remove {
                CollectionChanged -= value;
        }
    }
