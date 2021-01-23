    public class MyGrid : Canvas
    {
        protected static PropertyChangedCallback ItemsPropertyChangedCallback = new PropertyChangedCallback(ItemsPropertyChanged);
        public static DependencyProperty ItemsProperty = DependencyProperty.RegisterAttached("Items", typeof(INotifyCollectionChanged), typeof(MyGrid), new PropertyMetadata(null, ItemsPropertyChangedCallback));
        private static void ItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MyGrid thisGrid = (MyGrid)sender;
            if (thisGrid == null)
            {
                return;
            }
            thisGrid.UnregisterItems(e.OldValue as INotifyCollectionChanged);
            thisGrid.RegisterItems(e.NewValue as INotifyCollectionChanged);
            thisGrid.Refresh();
        }
        
        public INotifyCollectionChanged Items 
        { 
            get
            {
                return (INotifyCollectionChanged)GetValue(ItemsProperty);
            }
            set
            {
                SetValue(ItemsProperty, value);
            }
        }
        protected void UnregisterItems(INotifyCollectionChanged items)
        {
            if (items == null)
            {
                return;
            }
            items.CollectionChanged -= ItemsChanged;
        }
        protected void RegisterItems(INotifyCollectionChanged items)
        {
            if (items == null)
            {
                return;
            }
            items.CollectionChanged += ItemsChanged;
        }
        protected virtual void UpdateValues()
        {
            System.Diagnostics.Debug.WriteLine("Updating values");
        }
        protected virtual void UpdateGrid()
        {
            System.Diagnostics.Debug.WriteLine("Updating grid");
        }
        public void Refresh()
        {
            UpdateValues();
            UpdateGrid();
        }
        protected virtual void ItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Refresh();
        }
        public MyGrid()
        {
        }
    }
