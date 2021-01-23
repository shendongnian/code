    public class RadGridViewExt : Behavior<RadGridView>
    {
        private RadGridView Grid
        {
            get
            {
                return AssociatedObject as RadGridView;
            }
        }
        public INotifyCollectionChanged SelectedItems
        {
            get { return (INotifyCollectionChanged)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(INotifyCollectionChanged), typeof(RadGridViewExt), new PropertyMetadata(OnSelectedItemsPropertyChanged));
        private static void OnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var collection = args.NewValue as INotifyCollectionChanged;
            if (collection != null)
            {
                collection.CollectionChanged += ((RadGridViewExt)target).ContextSelectedItemsCollectionChanged;
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            Grid.SelectedItems.CollectionChanged += GridSelectedItemsCollectionChanged;
        }
        void ContextSelectedItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();
            Transfer(SelectedItems as IList, AssociatedObject.SelectedItems);
            SubscribeToEvents();
        }
        void GridSelectedItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();
            Transfer(AssociatedObject.SelectedItems, SelectedItems as IList);
            SubscribeToEvents();
        }
        private void SubscribeToEvents()
        {
            AssociatedObject.SelectedItems.CollectionChanged += GridSelectedItemsCollectionChanged;
            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged += ContextSelectedItemsCollectionChanged;
            }
        }
        private void UnsubscribeFromEvents()
        {
            AssociatedObject.SelectedItems.CollectionChanged -= GridSelectedItemsCollectionChanged;
            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged -= ContextSelectedItemsCollectionChanged;
            }
        }
        public static void Transfer(IList source, IList target)
        {
            if (source == null || target == null)
                return;
            target.Clear();
            foreach (var o in source)
            {
                target.Add(o);
            }
        }
    }
