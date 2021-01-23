    public class YourClass : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public string Test
            {
                get
                {
                    return _myInterface.Test;
                }
                set
                {
                    _myInterface.Test = value;
                    OnPropertyChanged();
                }
            }
        }
