    public class UsersViewModel : INotifyPropertyChanged
    {
        private User _currentUser = null;
        public UsersViewModel(IEnumerable<User> users)
        {
            this.Users = new ObservableCollection<User>(users);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public User CurrentUser
        {
            get
            {
                return this._currentUser;
            }
            set
            {
                this._currentUser = value;
                this.OnPropertyChanged("CurrentUser");
            }
        }
        public ObservableCollection<User> Users { get; protected set; }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
