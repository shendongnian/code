    public Class
    {
       ObservableCollection<TabInfo> _Tabs = new ObservableCollection<TabInfo>();
       public ObservableCollection<TabInfo> Tabs
       {
         get{return _Tabs;}
         set {_Tabs = value;}//Need to implement INotifyPropertyChanged [Link][2]
       }
       public TabInfo SelectedTab {get;set;}
    }
    public class TabInfo
    {
        public string TabName { get; set; }
        public UserControlViewModel MyUserControlViewModel{ get; set; }
    } 
