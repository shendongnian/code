    public class ViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<CategoryCounts> MyCollection { get; set; }
        public ViewModel()
        {
            MyCollection = new ObservableCollection<CategoryCounts>();
            MyCollection.Add(new CategoryCounts{CategoryName = "some category", CategoryCount = 22});
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
