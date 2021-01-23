    public class ViewModel
    {
        public ObservableCollection<MissingReportInfo> MissingReportInfos { get; set; } 
        public void Initialize()
        {
            MissingReportInfos = new ObservableCollection<MissingReportInfo>();
        }
    }
