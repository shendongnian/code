    public class UserViewModel: PropertyChangedBase
    {
        private bool _showUserWindow;
        public bool ShowUserWindow
        {
            get {return _showUserWindow; }
            set
            {
                _showUserWindow = value;
                OnPropertyChanged("ShowUserWindow"); //This is important!!!
            }
        }
    }
