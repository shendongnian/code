    Public class MainWindow: Page, INotifyPropertyChanged
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(name));
          }
      }
    private Int16 _currentImageIndex;
    public Int16 CurrentImageIndex{
      get{return _currentImageIndex;} 
      set
      {
        _currentImageIndex = value; 
        
        // fire PropertyChangedEventHandler
        OnPropertyChanged("CurrentImageIndex");
      }
    }
    public MainWindow()
    {
      this.DataContext = this;
    }
    
    public class ImageIndexConverter: ValueConverter
    {
      Convert
      {
        switch(value)
        {
          case 0: return Colors.Red;
          case 1: return Colors.Blue;
          //etc.
        }
      }
    
      ConvertBack
      {
        return null;
      }
    }
