    public class CheckedItem
    {
        public CheckedItem() { }
        public CheckedItem(string text, bool isChecked) : this()
        {
            this._text = text;
            this._isChecked = isChecked;
        }
        
        private string _text;
        public String Text;
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("IsSelected");
            }
        }
        
        private bool _isSelected;
        public bool IsSelected;
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
    private ObservableCollection<CheckedItem> checkItemCollection = 
        new ObservableCollection<CheckedItem>();
    public ObservableCollection<CheckedItem> CheckItemCollection
    {
        get { return checkItemCollection; }
        set
        {
            if (checkItemCollection == value)
                return;
            checkItemCollection = value;
            OnPropertyChanged("CheckItemCollection");
        }
    }
    
