        public event PropertyChangedEventHandler PropertyChanged;
        private static ObservableCollection<string> _fileList;
        public static ObservableCollection<string> fileList
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
