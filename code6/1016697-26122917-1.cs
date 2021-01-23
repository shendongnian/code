    //Warning not tested.....
    public partial class MainWindow : INotifyPropertyChanged
    {
    private DataSet _dataSet;
    private ObservableCollection<DataRow> _bindingListCollection;
    private string _filterString;
    public MainWindow()
    {
        InitializeComponent();
        _dataSet = new DataSet();
        _dataSet.ReadXml(@"D:\index.xml");
        FilterString=null;
       
    }
    public ObservableCollection<DataRow> BindingListCollection
    {
        get { 
             return  string.IsNullOrEmpty(FilterString)? 
                        new ObservableCollection<DataRow>
                        (from DataRow dr in _dataSet.Tables[0].Rows select dr)
                       :new ObservableCollection<DataRow>
                        (from DataRow dr in _dataSet.Tables[0].Rows
                             where dr.ItemArray.Count(c => c.ToString().IndexOf(FilterString,StringComparison.InvariantCultureIgnoreCase)>=0) > 0
                             select dr;)
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
