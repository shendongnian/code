    namespace MyNamespace
    {
        public class MyTabItem : TabItem, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            private bool _isButtonEnabled;
    
            public bool IsButtonEnabled
            {
                get { return _isButtonEnabled; }
    
                set
                {
                    if (value != _isButtonEnabled)
                    {
                        _isButtonEnabled = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
    }
