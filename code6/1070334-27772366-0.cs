    private const string CountString = "Count";
    private const string IndexerName = "Item[]";
    private const string KeysName = "Keys";
    private const string ValuesName = "Values";
    private void Insert(TKey key, TValue value, bool add)
    {
        if (key == null)
            throw new ArgumentNullException("key");
        TValue item;
        if (Dictionary.TryGetValue(key, out item))
        {
            if (add)
                throw new ArgumentException("An item with the same key has already been added.");
            if (Equals(item, value))
                return;
            Dictionary[key] = value;
            OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
        }
        else
        {
            Dictionary[key] = value;
            OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
        }
    }
    private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
    {
        OnPropertyChanged();
        if (CollectionChanged != null)
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, changedItem));
    }
    private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
    {
        OnPropertyChanged();
        if (CollectionChanged != null)
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
    }
    private void OnPropertyChanged()
    {
        OnPropertyChanged(CountString);
        OnPropertyChanged(IndexerName);
        OnPropertyChanged(KeysName);
        OnPropertyChanged(ValuesName);
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
