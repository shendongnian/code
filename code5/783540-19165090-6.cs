    public class ViewModel : INotifyPropertyChanged
    {
        private bool _IsOpenBottomBar;
        public bool IsOpenBottomBar
        {
            get
            {
                return _IsOpenBottomBar;
            }
            set
            {
                _IsOpenBottomBar = value;
                OnPropertyChanged("IsOpenBottomBar");
            }
        }
    
        public ViewModel()
        {
            _IsOpenBottomBar = true;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
