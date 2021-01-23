    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        private ObservableCollection<YourObjectTypeHere> _myItems;
        public ObservableCollection<YourObjectTypeHere> MyItems
        {
            get
            {
                return _myItems;
            }
            set
            {
                _myItems = value;
                OnPropertyChanged("MyItems");
            }
        }
    }
