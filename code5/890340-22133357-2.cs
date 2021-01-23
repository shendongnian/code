    public class EventLogByTimeViewModel : ViewModelBase
    {
        public DateTime Time { get; set; }
        public ObservableCollection<AnEvent> Type1Collection { get; set; }
        public ObservableCollection<AnEvent> Type3Collection { get; set; }
    }
