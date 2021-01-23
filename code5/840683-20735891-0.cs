    public class SyncViewModel : INotifyPropertyChanged
    {
        private string _miscStatus = "";
        public string MiscStatus
        {
            get{ return _miscStatus; }
            set
            {
                _miscStatus += value;
    			OnPropertyChanged("MiscStatus");
            }
        }
    	
    	#region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
