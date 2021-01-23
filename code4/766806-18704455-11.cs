        public class PropertyChangedBase:INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) 
                   handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
