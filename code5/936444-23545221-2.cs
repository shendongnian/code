     public class YourClassName : INotifyPropertyChanged //Hold control and hit period to add the using for this
        {
        
            PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged(String prop){
               PropertyChangedEventHandler handler = PropertyChanged;
    
               if(handler!=null){
                  PropertyChanged(this, new PropertyChangedEventArgs(prop));
               }
            }
        }
