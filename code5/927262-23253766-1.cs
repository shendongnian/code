    public class YourClass : INotifyPropertyChanged
    {
    private String _id;
    
    public String id
    {
       get{
            return _id;       
       }
       set{
           _id= value; OnPropertyChanged("id");OnPropertyChanged("ImageSource");
       }
    }
    private String _RootURL;
    
    public String RootURL
    {
       get{
            return _RootURL;     
       }
       set{
           _RootURL = value; OnPropertyChanged("RootURL"); OnPropertyChanged("ImageSource");
       }
    }
    private String _ImageSource;
    
    public String ImageSource
    {
       get{
            return RootURL+ id;       
       }
    }
    PropertyChangedEventHandler PropertyChanged;
    
    void OnPropertyChanged(String prop){
      PropertyChangedEventHandler handler = PropertyChanged;
      if(handler!=null){
        PropertyChanged(this,new PropertyChangedEventArgs(prop));
      }
    }
    }
