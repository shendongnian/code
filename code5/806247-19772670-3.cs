        public class ListData : INotifyPropertyChanged
        {
    
        public event PropertyChangedEventHandler PropertyChanged;
        private int _number;
        
        public int Number 
        { 
        get
        {
          return _number;
        } 
        set
        {
           if(value!= null)
        {
          _number = value;
          OnPropertyChanged("Number");
        }
        }
    
    private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            } 
    }
    
    
        public ObservableCollection<ListData> MyList {get;set;}
