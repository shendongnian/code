    public class MyItem : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        protected void OnPropertyChanged(string propertyName)
        {
            var evt = this.PropertyChanged;
            if (evt != null)
                evt(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private string _Header = "Item";
        public string Header
        {
            get
            {
                return this._Header;
            }
            set
            {
                if (this._Header != value)
                {
                    this._Header = value;
                    this.OnPropertyChanged("Header");
                }
            }
        }
        private ObservableCollection<MyItem> _SubItems = new ObservableCollection<MyItem>();
        public ObservableCollection<MyItem> SubItems
        {
            get
            {
                return this._SubItems;
            }
            set
            {
                if (this._SubItems != value)
                {
                    this._SubItems = value;
                    this.OnPropertyChanged("SubItems");
                }
            }
        }
    }
