    public class ViewModel : INotifyPropertyChanged
    {
        private BaseEntity _currentUser;
        public BaseEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; OnPropertyChanged();}
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
