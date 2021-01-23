    public class ExplorerViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _detailsMode;
        public bool DetailsMode
        {
            get { return _detailsMode; }
            set 
            {
                _detailsMode = value;
                OnPropertyChanged();
            }
        }
        private bool _tilesMode;
        public bool TilesMode
        {
            get { return _tilesMode; }
            set
            {
                _tilesMode = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<FileInfo> Files { get; set; } 
        public ExplorerViewModel()
        {
            var path = @"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE";
            Files = new ObservableCollection<FileInfo>(Directory.GetFiles(path).Select(x => new FileInfo(x)));
            
            TilesMode = true;
        }
    }
