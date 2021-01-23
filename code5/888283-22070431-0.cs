    public class ItemListViewModel
    {
        public ObservableCollection<Publication> Publications {get; set;}
    
        private Publication _currentItem;
        public Publication CurrentItem
        {
            get { return _currentItem; }
            set
            {
                if (_currentItem == value) return;
                _currentItem = value;
                RaisePropertyChanged("CurrentItem");
            }
        }
    }
