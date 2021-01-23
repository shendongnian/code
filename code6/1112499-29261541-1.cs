    public class ObservablePanel : Panel, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };
        protected override UIElementCollection CreateUIElementCollection(FrameworkElement logicalParent)
        {
            var oldObservableCollection = InternalChildren as INotifyCollectionChanged;
            if (oldObservableCollection != null)
                oldObservableCollection.CollectionChanged -= OnChildrenChanged;
            var collection = new ObservableUIElementCollection(this, logicalParent);
            collection.CollectionChanged += OnChildrenChanged;
            return collection;
        }
        private void OnChildrenChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged(sender, e);
        }
    }
    public class ObservableUIElementCollection : UIElementCollection, INotifyCollectionChanged
    {
        public ObservableUIElementCollection(UIElement visualParent, FrameworkElement logicalParent)
            : base(visualParent, logicalParent)
        {
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };
        public override int Add(UIElement element)
        {
            var i = base.Add(element);
            IList newItems = new List<UIElement> { element };
            IList oldItems = new List<UIElement>();
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItems, oldItems));
            return i;
        }
        ...
    }
