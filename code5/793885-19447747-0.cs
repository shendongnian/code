    //Your class
    public class ButtonText : INotifyPropertyChanged
    {
       private string _buttonText;
    
       public string ButtonValue
       {
          get{ return _buttonText; }
          set
          {
             //Sets the value of _buttonText to the value passed in an argument 
             _buttonText = value;
             RaisePropertyChanged("ButtonValue");
          }
       }
       protected void RaisePropertyChanged(string propertyName)
       {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
             handler(this, new PropertyChangedEventArgs(propertyName));
          }
       }
    
       public event PropertyChangedEventHandler PropertyChanged;
    }
