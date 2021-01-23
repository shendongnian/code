    namespace SPO
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                ListItemCollection = CollectionViewSource.GetDefaultView(LoadTasks());
                ListItemCollection.Filter = FilterTask;
            }
    
    
            public bool FilterTask(object value)
            {
                var entry = value as TaskEntry;
                if (entry != null)
                {
                    if (!string.IsNullOrEmpty(_filterString))
                    {
                        return entry.TaskName.Contains(_filterString);
                    }
                    return true;
                }
                return false;
            }
    
            /// <summary>
            /// Bind SP Data Source 
            /// </summary>
            private IEnumerable<TaskEntry> LoadTasks()
            {
                var data = GetListItems("http://intranet.contoso.com","Tasks");
                var result = XElement.Parse(data.OuterXml);
                XNamespace z = "#RowsetSchema";
                var taskItems = from r in result.Descendants(z + "row")
                                select new TaskEntry
                                    {
                                        TaskName = r.Attribute("ows_LinkTitle").Value,
                                        DueDate = r.Attribute("ows_DueDate") != null ? r.Attribute("ows_DueDate").Value : string.Empty,
                                        AssignedTo = r.Attribute("ows_AssignedTo") != null ? r.Attribute("ows_AssignedTo").Value : string.Empty,
                                    };
                return taskItems;
             }
    
    
            private XmlNode GetListItems(string webUri,string listTitle)
            {
                var client = new Lists.Lists();
                client.Url = webUri + "/_vti_bin/Lists.asmx";
                return client.GetListItems(listTitle, string.Empty, null, null, string.Empty, null, null);
            }
    
    
    
            public ICollectionView ListItemCollection
            {
                get { return _listItemCollection; }
                set { _listItemCollection = value; NotifyPropertyChanged("ListItemCollection"); }
            }
    
    
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
    
            public string FilterString
            {
                get { return _filterString; }
                set
                {
                    _filterString = value;
                    NotifyPropertyChanged("FilterString");
                    if (_listItemCollection != null)
                    {
                        _listItemCollection.Refresh();
                    }
                }
            }
    
    
            private ICollectionView _listItemCollection;
            private string _filterString;
    
        }
    
        public class TaskEntry
        {
            public string TaskName { get; set; }
            public string DueDate { get; set; }
            public string AssignedTo { get; set; }
        }
    }
