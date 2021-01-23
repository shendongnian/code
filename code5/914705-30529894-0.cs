    public class SelectableItem<T> : System.ComponentModel.INotifyPropertyChanged
    {
        public SelectableItem(T item)
        {
            Item = item;
        }
        public T Item { get; set; }
        bool _isSelected;
        public bool IsSelected {
            get {
                return _isSelected;
            }
            set {
                if (value == _isSelected)
                {
                    return;
                }
                _isSelected = value;
                if (PropertyChanged != null)
                { 
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("IsSelected"));
                }
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
