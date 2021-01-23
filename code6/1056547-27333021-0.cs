    public class ViewModelBase : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged(string propertyName)
       {
           OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
       }
       protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
       {
           var handler = PropertyChanged;
           if (handler != null)
               handler(this, args);
       }
    }
    public class MainPageViewModel : ViewModelBase
    {
        private bool _isOpen;
        public bool IsOpen 
        {
            get { return _isOpen; }
            set 
            {
                _isOpen = value;
                OnProperyChanged("IsOpen");
            }
        }
    }
