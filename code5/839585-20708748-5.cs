    public class HierarchicalData : PropertyChangedBase
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
    }
