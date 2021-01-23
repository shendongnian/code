    public class ControlState : INotifyPropertyChanged
    {
      private bool _redOneChecked;
      public bool RedOneChecked { 
        get { return _redOneChecked; }
        set
        {
          OnPropertyChanged("RedOneChecked");
          _redOneChecked = value;
          RedTwoChecked = RedOneChecked;
          GreenOneChecked = !RedTwoChecked;
        }
      }
    
      private bool _redTwoChecked;
      public bool RedTwoChecked
      {
        get { return _redTwoChecked; }
        set
        {
          OnPropertyChanged("RedTwoChecked");
          _redTwoChecked = value;
          RedOneChecked = RedTwoChecked;
          GreenOneChecked = !RedTwoChecked;
        }
      }
    
      private bool _greenOneChecked;
      public bool GreenOneChecked
      {
        get { return _greenOneChecked; }
        set
        {
          OnPropertyChanged("GreenOneChecked");
          _greenOneChecked = value;
          RedOneChecked = !GreenOneChecked;
          RedTwoChecked = !GreenOneChecked;
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged(string propertyName)
      {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
