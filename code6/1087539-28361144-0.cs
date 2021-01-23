    public class UserControlViewModel:INotifyPropertyChanged
    {
       private double _height;
       private double _width;
      public double _height
      {
         get { return _height;}
         set {
               if(_height == value)
               return;
               _height = value;
               OnPropertyChanged();
              }
      public double _width
      {
         get { return _width;}
         set {
               if(_width == value)
               return;
               _width = value;
              OnPropertyChanged();
             }
