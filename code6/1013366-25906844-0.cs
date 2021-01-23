    Public class YourClass : INotifyPropertyChanged
    {
    
        public YourClass()
        {
            ReadDongleFileCommand = new RelayCommand(ReadDongleFileCommandExecute);
        }
        public RelayCommand ReadDongleFileCommand { private set; get; }
        public void ReadDongleFileCommandExecute()
        {
            TextBoxInputText += "a"; //this if just for testing
        }
    
        private String _textBoxInputText;
        public String TextBoxInputText
        {
            get
            {
                return _textBoxInputText;
            }
            set
            {
                _textBoxInputText = value;
                OnPropertyChanged("TextBoxInputText");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
