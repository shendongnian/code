    public class MyViewModel
    {
        private readonly ObservableCollection<MyItem> _myItems =
            new ObservableCollection<MyItem>();
        public ObservableCollection<MyItem> MyItems { get{ return _myItems; } }
    }
