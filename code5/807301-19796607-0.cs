    public class Person : INotifyPropertyChanged
    {
       private Guid id;
       public Guid Id
       {
          get { return id; }
          private set
          {
             if(id != value)
             {
                id = value;
                NotifyPropertyChanged("Id");
             }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
           if (PropertyChanged != null)
           {
              PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }
        }
    }
