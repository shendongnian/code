      public class ValueHolder : INotifyPropertyChanged
      {
          private string _VHName;
          private string _VHValue;
          // Declare the event 
          public event PropertyChangedEventHandler PropertyChanged;
    
          public string VHName
          {
              get { return _VHName; }
              set
              {
                  _VHName = value;
                  // Call OnPropertyChanged whenever the property is updated
                  OnPropertyChanged("VHName");
              }
          }
          public string VHValue
          {
              get { return _VHValue; }
              set
              {
                  _VHValue= value;
                  // Call OnPropertyChanged whenever the property is updated
                  OnPropertyChanged("VHValue");
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
    }
