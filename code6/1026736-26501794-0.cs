    public class Validate
    {
        public static ErrorProperties ep = new ErrorProperties();
        public static bool ValidateThis(string PropertyName, string PropertyValue)
        {
            if (PropertyValue.Length > 10)
            {
                ep.ErrorPropertyName = PropertyName;
                return true;
            }
            return false;
        }
    }
    public class ErrorProperties
    {
        public string ErrorPropertyName { get; set; }
        public string Error { get; set; }
    }
    public class data : INotifyPropertyChanged
    {
        private ObservableCollection<ErrorProperties> _ErrorList = new ObservableCollection<ErrorProperties>();
        public ObservableCollection<ErrorProperties> ErrorList
        {
            get
            {
                return _ErrorList;
            }
            set
            {
                if (_ErrorList != value)
                {
                    _ErrorList = value;
                    OnPropertyChanged("ErrorList");
                }
            }
        }
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    if (Validate.ValidateThis("Name", value))
                        ErrorList.Add(Validate.ep);
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    if (Validate.ValidateThis("FirstName", value))
                        ErrorList.Add(Validate.ep);
                    OnPropertyChanged("FirstName");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                // Raise the PropertyChanged event
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
