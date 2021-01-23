    public class MyViewModelType : INotifyPropertyChanged {
        private PlayerElements _player;
        public PlayerElements Player {
            get { return _player; }
            set { 
                _player = value;
                OnPropertyChanged("Player");
            }
        }
        .
        .
        .
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string propertyName) {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName);
        }
    }
