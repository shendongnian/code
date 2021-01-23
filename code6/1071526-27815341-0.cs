       public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            //Populate the TaskItems collection using BindSPDataSource() method
            
        }
        private String _filter = String.Empty;
        public String Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                if (_filter == value)
                {
                    return;
                }
                _filter = value;
                OnPropertyChanged();
                TaskItems = new ObservableCollection<TaskItem>(TaskItems.Where(x => x.AssignedTo.ToLower().Contains(_filter) ||
                    x.DueDate.ToLower().Contains(_filter) ||
                    x.TaskName.ToLower().Contains(_filter)
                    ));
            }
        }
        private ObservableCollection<TaskItem> _taskItem;
        public ObservableCollection<TaskItem> TaskItems
        {
            get
            {
                return _taskItem;
            }
            set
            {
                if (_taskItem == value)
                {
                    return;
                }
                _taskItem = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class TaskItem
    {
        public String TaskName { get; set; }
        public String DueDate { get; set; }
        public String AssignedTo { get; set; }
    }
