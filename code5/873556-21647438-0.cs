    public class ViewModel : INotifyPropertyChanged
    {
        // this property will hold the selected value in combo box
        private UserType _userType;
        public UserType UserType
        {
            get { return _userType; }
            set
            {
                _userType = value;
                OnPropertyChanged();
            }
        }
    
        // this property will return all available values for combo box
        public IEnumerable<UserType> UserTypes
        {
            get { return Enum.GetValues(typeof (UserType)).Cast<UserType>(); }
        }
    
        // INotifyPropertyChanged must be implemented to notify the UI about changed properties
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
