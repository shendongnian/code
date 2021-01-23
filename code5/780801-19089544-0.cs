    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SomeItem> VmList { get; set; }
        List<SomeItem> List1 = new List<SomeItem>(); 
        List<SomeItem> List2 = new List<SomeItem>(); 
        public ViewModel()
        {
            // VmList is the item source for the grid
            VmList = new ObservableCollection<SomeItem>();
            // create two lists
            for (int i = 0; i < 10; i++)
            {
                List1.Add(new SomeItem{ID = "1", Name = "Name " + i});
            }
            for (int i = 0; i < 10; i++)
            {
                List1.Add(new SomeItem { ID = "2", Name = "Name (2) " + i });
            }
            // merge the two separate lists
            VmList.AddRange(List1);
            VmList.AddRange(List2);
            // get the view
            var lcv = CollectionViewSource.GetDefaultView(VmList);
            // apply a filter
            lcv.Filter = o =>
                {
                    var someItem = o as SomeItem;
                    if (someItem != null)
                    {
                        return someItem.ID == "2";
                    }
                    return false;
                };
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
    public class SomeItem:INotifyPropertyChanged
    {
        private string _id;
        public string ID
        {
            [DebuggerStepThrough]
            get { return _id; }
            [DebuggerStepThrough]
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private string _name;
        public string Name
        {
            [DebuggerStepThrough]
            get { return _name; }
            [DebuggerStepThrough]
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
    public static class Extensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> list)
        {
            foreach (T t in list)
            {
                collection.Add(t);
            }
        }
    }
