    namespace WpfApplication1
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            #region Members
            private int _myLabel;
            #endregion Members
    
            #region Properties
            public int MyLabel
            {
                get
                {
                    return _myLabel;
                }
                set
                {
                    _myLabel = value;
                    NotifyPropertyChanged("MyLabel");
                }
            }
    
            #endregion Properties
    
            public MainViewModel()
            {
            }
    
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            #endregion
        }
    }
