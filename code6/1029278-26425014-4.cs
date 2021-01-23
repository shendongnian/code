    using System.ComponentModel;
    
    public class YourClassName : INotifyPropertyChanged
        private List<Object> _listOneObjects;
        public List<Object> listOneObjects 
        {
            get{ return _listOneObjects; }
            set{ _listOneObjects = value; OnPropertyChanged("listOneObjects"); }
        }
    
    private Object _listOneSelectedItem;
    public Object listOneSelectedItem
    {
        get{ return _listOneSelectedItem; }
        set{ _listOneSelectedItem = value;  OnPropertyChanged("listOneSelectedItem");  }
    }
    
    
    private List<Object> _listTwoObjects ;
    public List<Object> listTwoObjects 
    {
        get{ return _listOneObjects; }
        set{ _listOneObjects = value; OnPropertyChanged("listTwoObjects "); }
    }
    private Object _listTwoSelectedItem
    public Object listTwoSelectedItem
    {
        get{ return _listTwoSelectedItem; }
        set{ _listTwoSelectedItem= value; OnPropertyChanged("listTwoSelectedItem"); }
    }
    public ICommand TouchDownCommand{ get{ return _TouchDownCommand; }
    private _TouchDownCommand;
    public YourClassName(){
       this._TouchDownCommand= new ActionCommand(TouchDownExecuted);
    }
    private void TouchDownExecuted(){
       listTwoObjects.clear();
       listTwoObjects.Add(listOneSelectedItem);
       OnPropertyChanged("listTwoObjects");
    }
    PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(String prop){
        PropertyChangedEventHandler handler = PropertyChanged;
        if(handler != null)
        {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    
    }
    
