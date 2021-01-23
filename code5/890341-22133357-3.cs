    public class MainViewModel : ViewModelBase
    {
        private IEventLogByTimeVMFactory _factory;
    
        public MainViewModel()
        {
            EventLogs = new ObservableCollection<EventLogByTimeViewModel>();
            _factory = new MyFactoryImplementation();
        }
    
        public ObservableCollection<EventLogByTimeViewModel> EventLogs { get; set; }
    
        public void LoadData(IList<EventEventLogByTimeViewModel> eventLogs)
        {
            var vms = _factory.GenerateVM(eventLogs);
    
            EventLogs.Clear();
    
            foreache(vm in vms)
            {
                EventLogs.Add(vm);
            }
        }
    }
