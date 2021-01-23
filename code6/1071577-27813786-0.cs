    public class Global : INotifyPropertyChanged
    {
        private static  Global _instance = new Global();
    
        public static Global Instance
        {
            get { return _instance; }
        }
    
        private string _isConnected;
    
        public string IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                OnPropertyChanged("IsConnected");
            }
        }
    
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
