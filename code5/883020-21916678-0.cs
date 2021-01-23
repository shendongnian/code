    public class Bind : INotifyPropertyChanged
    {
       private string _text1;
       public string text1
       {
          get
          {
             return _text1;
          }
          set
          {
             _text1=value;
             NotifyPropertyChanged("text1");
          }
       }
       
      public event PropertyChangedEventHandler PropertyChanged;
      
      public void NotifyPropertyChanged(string propertyName)
      {
         if (PropertyChanged != null)
         {
             PropertyChanged(this, 
                 new PropertyChangedEventArgs(propertyName));
         }
      }  
    }
