    class ItemManager : INotifyPropertyChanged
    {
        private ItemContainerRoot _myRoot;
        public ItemContainerRoot Root
        {
            get { return _myRoot; }
            
            set
            {
                _myRoot = value;
                OnPropertyChanged("Root");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }    
