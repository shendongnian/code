    public class Resource : INotifyPropertyChanged
    {
        public Resource()
        {
            Name = "";
            EMail = "";
            Date = "";
            Time = "";
            SWList = new ObservableCollection<string>();
        }
        // TODO: do this for all properties:
        private string name;
        public string Name
        {
            get { return name;}
            set 
            {
                if(name != value) 
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
       
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName);
            }
        }
    }
