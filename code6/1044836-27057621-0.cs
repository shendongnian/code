    public class TabData : INotifyPropertyChanged
    {
        private bool isselected;
        public string Header { get; set; }
        public object Content { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsSelected
        {
            get { return isselected; }
            set
            {
                if (ViewModel.CurrentItem.IsSelected && ViewModel.CurrentItem != this)
                {
                    ViewModel.CurrentItem.IsSelected = false;
                }
                isselected = value;
                RaisePropertyChanged("IsSelected");
                if (ViewModel.CurrentItem != this)
                    ViewModel.CurrentItem = this;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
