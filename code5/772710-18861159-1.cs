        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _fileList;
        public ObservableCollection<string> fileList
        {
            get
            {
                return _fileList;
            }
            set
            {
                _fileList= value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("fileList"));
            }
        }
