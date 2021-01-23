    internal class Item
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ItemCollection _children;
        public Item()
        {
            Children = new ItemCollection();
        }
        public Item Parent { get; private set; }
        public ItemCollection Children
        {
            get { return _children; }
            set
            {
                if (_children != null)
                {
                    _children.CollectionChanged -= Children_CollectionChanged;
                }
                if (value != null)
                {
                    value.CollectionChanged += Children_CollectionChanged;
                    // Notify about previously (never notified) added items 
                    if (value.Count > 0)
                    {
                        value.RaiseCollectionChanged(
                            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
                    }
                }
                _children = value;
            }
        }
        public string Name { get; set; }
        private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e != null)
            {
                if (e.NewItems != null)
                {
                    IEnumerable<Item> newItems = e.NewItems.OfType<Item>();
                    foreach (Item item in newItems)
                    {
                        item.Parent = this;
                    }
                }
                if (e.OldItems != null)
                {
                    IEnumerable<Item> oldItems = e.OldItems.OfType<Item>();
                    foreach (Item item in oldItems)
                    {
                        item.Parent = null;
                    }
                }
            }
        }
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
        public void Prune()
        {
            Item parent = Parent;
            if (parent != null)
            {
                parent.Children.Remove(this);
                while (parent.Children.Count <= 0)
                {
                    Item grandParent = parent.Parent;
                    if (grandParent != null)
                    {
                        grandParent.Children.Remove(parent);
                        parent = grandParent;
                    }
                }
            }
        }
    }
