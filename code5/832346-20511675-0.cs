    public class DATA : : INotifyPropertyChanged
    {
        private double _channelRecordTimeItemWidth;
        private double _channelRecordTimeItemHeight;
        private Thickness _channelRecordTimeItemsMargin;
        private List<RecordTime> _listRecordTime;
    
        public double ChannelRecordTimeItemWidth 
        {
            get { return _channelRecordTimeItemWidth; }
            set
            {
                _channelRecordTimeItemWidth = value;
                OnPropertyChanged("ChannelRecordTimeItemWidth");
            }
        }
    
        public double ChannelRecordTimeItemHeight 
        {
            get { return _channelRecordTimeItemHeight; }
            set
            {
                _channelRecordTimeItemHeight = value;
                OnPropertyChanged("ChannelRecordTimeItemHeight");
            }
        }
    
        public Thickness ChannelRecordTimeItemsMargin 
        {
            get { return _channelRecordTimeItemsMargin; }
            set
            {
                _channelRecordTimeItemsMargin = value;
                OnPropertyChanged("ChannelRecordTimeItemsMargin");
            }
        }
    
        public List<RecordTime> ListRecordTime 
        {
            get { return _listRecordTime; }
            set
            {
                _listRecordTime = value;
                OnPropertyChanged("ListRecordTime");
            }
        }
    
        public DATA()
        {
            ChannelRecordTimeItemWidth = 1000;
            ChannelRecordTimeItemHeight = 20;
            ChannelRecordTimeItemsMargin = new System.Windows.Thickness(0, 0, 0, 0);
            ListRecordTime = null;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
