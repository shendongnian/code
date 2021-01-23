    public class YourData : INotifyPropertyChanged
    {
      private string _textBoxData;
      public YourData()
      {
      }
      public string TextBoxData
      {
          get { return _textBoxData; }
          set
          {
              _textBoxData = value;
              // Call OnPropertyChanged whenever the property is updated
              OnPropertyChanged("TextBoxData");
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
