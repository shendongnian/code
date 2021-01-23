    namespace WpfStackoverflow
    {
    
    
        public class Parent:INotifyPropertyChanged
        {
            private Mine _mine;
            public Mine Mine
            {
                get
                {
                    return _mine;
                }
                set
                {
                    _mine = value;
                    NotifyPropertyChanged();
                }
            }
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
        public class Mine : INotifyPropertyChanged
        {
            private string _name;
            public string Name { get { return _name; }
                set
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
    }
