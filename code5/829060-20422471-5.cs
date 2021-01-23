    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Data() { Name = "Hello World!" };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            window.BindingGroup.CommitEdit();
        }
    }
    public class Data : INotifyPropertyChanged
    {
        private int id = -1;
        private bool updated = true;
        private string text;
        private string name;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public bool Updated
        {
            get
            {
                return updated;
            }
            set
            {
                updated = value;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            updated = true;
        }
        #endregion
    }
    public class StringRangeValidationRule : ValidationRule
    {
        private int _minimumLength = 1;
        private string _errorMessage;
        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup group = (BindingGroup)value;
            var item = group.Items[0];
            string inputString = (group.GetValue(item, "Name") ?? string.Empty).ToString();
            if (true || string.IsNullOrEmpty(inputString) || inputString.Length < MinimumLength)
            {
                return new ValidationResult(false, this.ErrorMessage);
            }
            return ValidationResult.ValidResult;
        }
    }
