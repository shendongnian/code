    public class ClientStateManager : INotifyPropertyChanged
    {
        #region Private Variables
        private bool isForceToTop;
        private bool isClientEnabled;
        #endregion
        #region Public Properties
        public bool IsForceToTop
        {
            get { return isForceToTop; }
            set
            {
                isForceToTop = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsClientEnabled
        {
            get { return isClientEnabled; }
            set
            {
                isClientEnabled = value;
                NotifyPropertyChanged();
            }
        }       
        #endregion
        #region Private Methods
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Public Methods
        public void Lock() => this.IsClientEnabled = false;
        public void UnLock() => this.IsClientEnabled = true;
        public void SetTop() => this.IsForceToTop = true;
        public void UnSetTop() => this.IsForceToTop = false;
        #endregion
        #region Public Events
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion
    }
