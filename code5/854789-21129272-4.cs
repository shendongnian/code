    public class Camera : INotifyPropertyChanged
    {
            private ObservableCollection<Camera> _extension;
            public ObservableCollection<Camera> extension;
            {
                get { return _extension; }
                set
                {
                    if (_extension != value)
                    {
                         _extension= value;
                         OnPropertyChanged("extension");
                    }
    
                }
            }
    
            /// <summary>
            /// Raises the PropertyChanged notification in a thread safe manner
            /// </summary>
            /// <param name="propertyName"></param>
            private void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
    }
