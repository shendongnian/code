    public class MyViewModel : INotifyPropertyChanged
    {
       //Standard INotifyPropertyChanged implementation, pick your favorite
    
       private String myTextValue;
       public String MyTextValue
       {
          get { return myTextValue; }
          set
          {
              myTextValue = vaule;
              OnPropertyChanged("MyTextValue");
          }
    }
