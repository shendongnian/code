        public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<Items> _items;
        Items _item;
        private static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string _filter1 = "";
        private string _filter2 = "";
        private string _filter3 = "";
        public ViewModel()
        {
            _items = new List<Items>();
            for (int i = 0; i < 1000; i++)
            {
                _item = new Items();
                _item.Text1 = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                _item.Text2 = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                _item.Text3 = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                _items.Add(_item);
            }
            ItemList = new ObservableCollection<Items>(_items);
            ItemView = (CollectionView)CollectionViewSource.GetDefaultView(ItemList);
            ItemView.Filter = TextFilter;
        }
        private bool TextFilter(object obj)
        {
            var data = obj as Items;
            if (data != null)
            {
                return data.Text1.StartsWith(_filter1) && data.Text2.StartsWith(_filter2) && data.Text3.StartsWith(_filter3);
            }
            return false;
        }
        private void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public ObservableCollection<Items> ItemList { get; set; }
        public CollectionView ItemView { get; set; }
        public string Filter1
        {
            get { return _filter1; }
            set
            {
                _filter1 = value;
                NotifyPropertyChanged("Filter1");
                ItemView.Refresh();
            }
        }
        public string Filter2
        {
            get { return _filter2; }
            set
            {
                _filter2 = value;
                NotifyPropertyChanged("Filter2");
                ItemView.Refresh();
            }
        }
        public string Filter3
        {
            get { return _filter3; }
            set
            {
                _filter3 = value;
                NotifyPropertyChanged("Filter3");
                ItemView.Refresh();
            }
        }
    }
    public class Items
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
    }
