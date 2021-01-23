    public class MyDataContext
    {
        public MyDataContext()
        {
            ColorContainer _cContainer = new ColorContainer(); ;
            _cContainer.boxStart = Colors.Orange;
            _cContainer.boxEnd = Colors.Green;
            //note that all items use this _cContainer instance
            _items = new ObservableCollection<ComboboxItem>();
            _items.Add(new ComboboxItem() { Name = "name1", URL = "url1", CContainer = _cContainer });
            _items.Add(new ComboboxItem() { Name = "name2", URL = "url2", CContainer = _cContainer });
        }
        ObservableCollection<ComboboxItem> _items;
        public ObservableCollection<ComboboxItem> Items
        {
            get { return _items; }
        }
    }
