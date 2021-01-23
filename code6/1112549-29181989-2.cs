    class SeriesData : INotifyPropertyChanged
    {
        private ObservableCollection<SeriesInfo> _seriesInfo;
        public ObservableCollection<SeriesInfo> SeriesInfo
        {
            set{ SetProperty(ref _seriesInfo, value); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
       
        private bool SetProperty<T>(ref T storage, T value, [CallermemberName] string propertyName = null)
        {
            if(Equals(storage,value)) return false;
            storage = value;
            var handler = PropertyChanged;
            if(handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
