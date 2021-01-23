    /// <summary>
        /// This is my Model
        /// </summary>
        public class Document : INotifyPropertyChanged
        {
            private string _name;
            private string _data;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
    
            public string Data
            {
                get { return _data; }
                set
                {
                    _data = value;
                    OnPropertyChanged();
                }
            }
    
            public Document(string name, string data)
            {
                Name = name;
                Data = data;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
