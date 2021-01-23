    public class HierarchicalData : System.ComponentModel.INotifyPropertyChanged
    {
        
        public string DisplayName { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public ObservableCollection<HierarchicalData> Children { get; private set; }
        public HierarchicalData()
        {
            Children = new ObservableCollection<HierarchicalData>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
