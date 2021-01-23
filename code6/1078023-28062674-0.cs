       public class FileInformationForOverview : INotifyPropertyChanged
        {
            public int IdOnList { get; set; }
            public String Name { get; set; }
            public Int64 Size { get; set; }
            public String HumanReadableSize { get; set; }
            public String Path { get; set; }
            public String Type { get; set; }
            public long JobId { get; set; }
            public Boolean IsChecked { get; set; }
            public cfmData CfmData { get; set; }
            public bool Paused { get; set; }
            public String Deeplink { get; set; }
            public String Status { get; set; }
            public String LastStatus { get; set; }
    
            private int _progressValue;
            public int ProgressValue
            {
                get { return _progressValue; }
                set
                {
                    _progressValue = value;
                    OnPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
