    public class ServerViewModel : INotifyPropertyChanged {
        private string _server;
        public string Server {
            get { return _server; }
            set {
                _server = value;
                OnPropertyChanged(nameof(Server));
            }
        }
        
        private int _port;
        public int Port {
            get { return _port; }
            set {
                _port = value;
                OnPropertyChanged(nameof(Port));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
