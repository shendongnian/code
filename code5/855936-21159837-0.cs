    public class DayOfWeekElement : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
    
       private void NotifyPropertyChanged(string propertyName)
       {
           if (PropertyChanged != null)
           {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }
       }
    
    
       private bool isActive = false;
       public bool IsActive { 
          get
          {
              return this.isActive;
          } 
          set
          {
              if (value != this.isActive)
              {
                 this.isActive= value;
                 NotifyPropertyChanged("IsActive");
              }
          }  
       }
    }
