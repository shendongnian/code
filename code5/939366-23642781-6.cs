    public class SampleModel : INotifyPropertyChanged
    {
      bool _isAuthenticated = false;
      public bool IsAuthenticated {
        get { return _isAuthenticated; }
        set {
          if (_isAuthenticated != value) {
            _isAuthenticated = value;
            OnPropertyChanged("IsAuthenticated"); // raising this event is key to have binding working properly
          }
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      void OnPropertyChanged(string propName) {
        if (PropertyChanged != null) {
          PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
      }
    }
