    class YourClass : INotifyPropertyChanged
    {
            private String _wordName;
            public String WordName 
            {
                get { return _wordName; }
                set
                {
                    if (_wordName != value)
                    {
                         _wordName= value;
                         OnPropertyChanged("WordName");
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
