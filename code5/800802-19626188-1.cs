    public class loggedin : INotifyPropertyChanged
        {
            public string _aliasname = null;
            public string aliasname
            {
                get { return _aliasname; }
                set
                {
                    _aliasname = value;
                    OnPropertyChanged("aliasname");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
