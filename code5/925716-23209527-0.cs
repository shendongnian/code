    public class UserSettings : INotifyPropertyChanged {
        
        public string RootDir {
            get { return Settings.Default.RootDir; }
            set {
                Settings.Default.RootDir = value;
                OnPropertyChanged( "RootDir" );
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public OnPropertyChanged( string property ) {
                PropertyChangedEventHandler h = PropertyChanged;
                if ( h != null ) {
                    h(property);
                }
            }
        }
    }
