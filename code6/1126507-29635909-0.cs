    public class MyItem : ViewModelBase
    {
        // Current implementation goes here...
        // GridVisibility implementation
        private bool _isGridVisible = false;
        public bool GridVisibility
        {
            get { return _isGridVisible; }
            set
            {
                _isGridVisible = value;
                RaisePropertyChanged();
            }
        }
    }
