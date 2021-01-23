    public class Items : INotifyPropertyChanged, IWeakEventListener
    {
        #region IWeakEventListener
        public bool ReceiveWeakEvent(Type managerType, Object sender, EventArgs e)
        {
            if (sender == this._itemsCollection && managerType == typeof(CollectionChangedEventManager))
            {
                // Your collection has changed, you should add/remove
                // subscription for PropertyChanged event
                UpdateSubscriptions((NotifyCollectionChangedEventArgs)e);
                return true;
            }
            if (sender is Item && managerType == typeof(PropertyChangedEventManager))
            {
                // The Visible property of an Item object has changed
                // You should handle it properly here, for example, like this:
                this.ItemsVisible = this._itemsCollection.All(i => i.Visible);
                return true;
            }
            return false;
        }
        private void UpdateSubscriptions(NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Item item in e.NewItems)
                    {
                        PropertyChangedEventManager.AddListener(item, this, "Visible");
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Item item in e.OldItems)
                    {
                        PropertyChangedEventManager.RemoveListener(item, this, "Visible");
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (Item item in this._itemsCollection)
                    {
                        PropertyChangedEventManager.RemoveListener(item, this, "Visible");
                        PropertyChangedEventManager.AddListener(item, this, "Visible");
                    }
                    break;
                 default:
                    break;
            }
        }
    ...
        public Items()
        {
            _itemsVisible = true;
            _itemsCollection = new ObservableCollection<Item>();
            CollectionChangedEventManager.AddListener(_itemsCollection, this);
        }
    }
