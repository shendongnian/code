    // Your ViewModel should implement INotifyPropertyChanged
    class ViewModel : INotifyPropertyChnaged
    {
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return true; }
            set { 
                _isEnabled = value
                 SetPropertyChanged("IsEnabled");  // Add this to your setter
            };
        }
        // This comes from INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged( this, new PropertyChangedEventArgs(property) );
            }
        }
    }
