     public class WindowViewModel
        {
            public ObservableCollection<DataSource> SourceData { get; set; }
           
            public WindowViewModel()
            {
                Initialize();
            }
            private void Initialize()
            {
                SourceData = new ObservableCollection<DataSource>
                {
                    new DataSource() {Status = "Stop", ServerName = "Test 1", SourceDatabase = "Unknown",DestinationDatabase = "blabla....."},
                    new DataSource() {Status = "Work", ServerName = "Test 2", SourceDatabase = "Unknown",DestinationDatabase = "blabla....."},
                    new DataSource() {Status = "Stop", ServerName = "Test 3", SourceDatabase = "Unknown",DestinationDatabase = "blabla....."}
                };
            }
        }
