    public class ViewModel : INotifyPropertyChanged
    {
        public string StatusText
        {
            get { return _statusText; }
            set
            {
                _statusText = value;
                RaisePropertyChanged("StatusText");
            }
        }
 
        // TODO implement INotifyPropertyChanged
    } 
