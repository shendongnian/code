    public class ViewModel : INotifyPropertyChanged
    {
        private bool _IsBusy;
        public bool IsBusy
            {
                get { return _IsBusy; }
                set { _IsBusy = value; RaisePropertyChanged("IsBusy"); }
            }
    
        private string _Message;
        public string Message
            {
                get { return _Message; }
                set { _Message = value; RaisePropertyChanged("Message"); }
            }
    
        public RelayCommand _ShowProgressBar { get; set; }
    
        public ViewModel()
            {
                _ShowProgressBar = new RelayCommand(() => ShowProgressBar());
            }
    
        private void ShowProgressBar()
            {
                IsBusy = true;
                Message = "Loading...";
            }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
    }
