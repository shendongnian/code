    public class MyCustomType: INotifyPropertyChanged
    {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
    
            private bool _IsCopying;
    
            public bool IsCopying
            {
                get { return _IsCopying; }
                set
                {
                    _IsCopying = value;
                    OnPropertyChanged("IsCopyingText");
                }
            }
    
            public string IsCopyingText
            {
                get
                {
                    if(IsCopying) return "Working...";
                    else return "Waiting for command...";
                }
            }
    }
