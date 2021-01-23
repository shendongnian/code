    public class MyFileInfo : INotifyPropertyChanged {
      bool _ifPrint;
      bool _isValid;
      public bool IfPrint {
        get { return _ifPrint; }
        set {
           if(_ifPrint != value) {
              _ifPrint = value;
              OnPropertyChanged("IfPrint");
           }
        }
      }
      
      public bool IsValid {
        get { return _isValid; }
        set {
           if(_isValid != value) {
               _isValid = value;
               OnPropertyChanged("IsValid");
           }
        }
      }
      //Implement INotifyPropertyChanged
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged(string prop){
         var handler = PropertyChanged;
         if(handler != null) handler(this, new PropertyChangedEventArgs(prop));
      }
      //.... should do the same for the remaining properties....
      //...
    }
