        private ObservableCollection<string> listString;
        public ObservableCollection<string> ListString 
        {
            get
            {
                return listString;
            }
            set
            {
                listString = value;
                NotifyPropertyChanged("ListString"); // method implemented below
            }
        }
