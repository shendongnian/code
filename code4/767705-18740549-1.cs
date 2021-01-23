    public class ViewModel : INotifyPropertyChanged
    {
        private Model.WorkLogItem _newItem;
        public ViewModel()
        {
            NewItem = new Model.WorkLogItem();
            WorkLog  = new ObservableCollection<Model.WorkLogItem>();
        }
        public Model.WorkLogItem NewItem
        { 
            get { return _newItem; }
            set
            {
                _newItem = value;
                FirePropertyChanged("NewItem");
            }
        }
        public ObservableCollection<Model.WorkLogItem> WorkLog { get; set; }
        // INotifyPropertyChanged implementation here...
    }
