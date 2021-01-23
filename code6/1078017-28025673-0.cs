    public class TabEntry : INotifyPropertyChanged
    {
        public TabEntry()
        {
            DataGridEntries = new ObservableCollection<DataGridEntry>();
        }
        public string Description { get; set; }
        public ObservableCollection<DataGridEntry> DataGridEntries { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
