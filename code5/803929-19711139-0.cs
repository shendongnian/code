    public sealed class MainViewModel : INotifyPropertyChanged
    {
        private int _tabNumber = 0;
        public int TabNumber
        {
            get { return _tabNumber; }
            set
            {
                if (value == _tabNumber) return;
                _tabNumber = value;
                OnPropertyChanged("TabNumber");
            }
        }
        private void ChangeTab(int tabNumber)
        {
            TabNumber = tabNumber;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
