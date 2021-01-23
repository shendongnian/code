    public class Record : INotifyPropertyChanged
    {      
        private ObservableCollection<Property> _Properties;
        public ObservableCollection<Property> Properties
        {
            get { return _Properties; }
            set
            {
                _Properties = value;
                OnPropertyChanged("Properties");
            }
        }
        public Record(List<Property> properties)
        {
            _Properties = new ObservableCollection<Property>();
            foreach (var property in properties)
                _Properties.Add(property);
        }
        public Record(List<Property> properties)
        {
            _Properties = new ObservableCollection<Property>();            
            foreach (var property in properties)
                _Properties.Add(property);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        //protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        //{
        //    PropertyChangedEventHandler handler = this.PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, args);
        //    }
        //}
    }    
