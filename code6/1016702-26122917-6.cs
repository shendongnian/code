    //Warning not tested.....
    public partial class MainWindow : INotifyPropertyChanged
    {
    private DataSet _dataSet;
    private string _filterString;
    public MainWindow()
    {
        InitializeComponent();
        _dataSet = new DataSet();
        _dataSet.ReadXml(@"D:\index.xml");
        FilterString=null;
       
    }
    public DataTable BindingListCollection
    {
        get {
             return FilteredList.CopyToDataTable();
            }
    }
    public IEnumerable<DataRow> FilteredList
    {
        get {
             //may need to check _dataSet is not null 
             return  string.IsNullOrEmpty(FilterString)?                        
                        from DataRow dr in _dataSet.Tables[0].Rows select dr
                       :from DataRow dr in _dataSet.Tables[0].Rows
                             where dr.ItemArray.Count(c => c.ToString().IndexOf(FilterString,StringComparison.InvariantCultureIgnoreCase)>=0) > 0
                             select dr;
            }
    }
    public string FilterString
    {
        get { return _filterString; }
        set
        {
            _filterString = value;
            
            NotifyPropertyChanged("FilterString");
            NotifyPropertyChanged("BindingListCollection");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string property)
    {
        if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
    }
    }
