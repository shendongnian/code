    public class Inventory 
    {
        private ObservableCollection<Item> _inventoryList = new ObservableCollection<Item>();
        public decimal _total;
        // You probably want INPC for the property here too so it can update any UI elements bound to it
        public decimal Total { get { return _total; } set { _total = value; } }
        // Constructor     
        public Inventory() 
        {
            WireUpCollection();
        }
        private void WireUpCollection()
        {
            // Listen for change events
            _inventoryList.CollectionChanged += CollectionChanged;
        }
        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Check what was added - I'll leave this to you, the e.NewItems are the items that
            // have been added, e.OldItems are those that have been removed
            // Here's a contrived example for when an item is added. 
            // Don't forget to also remove event handlers using inpc.PropertyChanged -= Collection_PropertyChanged;
            var inpc = e.NewItems[0] as INotifyPropertyChanged;
            
            if(inpc != null)
              inpc.PropertyChanged += Collection_PropertyChanged;
        }
        private void Collection_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RecalculateTotal();
        }
        private void RecalculateTotal()
        { 
            // Your original code here which should feed the backing field
        }
    }
