    public class SettingsViewModel : INotifyPropertyChanged
    {
        bool _isPipelinedModeling;
        public bool IsPipelinedModeling
        {
            get { return _isPipelinedModeling; }
            set
            {
                if (_isPipelinedModeling == value)
                    return;
                _isPipelinedModeling = value;
                RaisePropertyChanged();
            }
        }
        #region INotifyPropertyChanged implementation
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged implementation
    }
