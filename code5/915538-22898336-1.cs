    public class DataItem : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       
       private int id;
       public int Id
       {
          get { return id; }
          set
          {
             if(id != value)
             {
                id= value;
                OnPropertyChanged("Id");
             }
          }
       }
    
      // Create the OnPropertyChanged method to raise the event 
      protected void OnPropertyChanged(string name)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
         {
            handler(this, new PropertyChangedEventArgs(name));
         }
      }
    }
