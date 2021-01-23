    public class SwatchThumbnail : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged(string prop){
        var handler = PropertyChanged;
        if(handler != null) handler(this, new PropertyChangedEventArgs(prop));
      }
      string _name;
      public string name {
        get { return _name;}
        set { 
           if(_name != value) {
              _name = value;
              OnPropertyChanged("name");
           }
        }
      }
      List<SolidColorBrush> _colors;
      public List<SolidColorBrush> colors {
        get {
           return _colors;
        }
        set {
           _colors = value;
           OnPropertyChanged("colors");
        }
      }
      bool _selected;
      public bool selected {
        get {
           return selected;
        }
        set {
           if(_selected != value){
              _selected = value;
              OnPropertyChanged("selected");
           }
        }
      }
    }
