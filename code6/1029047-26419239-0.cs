    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public KeyInfo SelectedKeyInfo
        {
            get
            { 
                return _SelectedKeyInfo; 
            }
            set
            {
                _SelectedKeyInfo = value;
                OnPropertyChanged("SelectedKeyProducts");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
