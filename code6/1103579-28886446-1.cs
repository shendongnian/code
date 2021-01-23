    public partial class Window1 : Window,INotifyPropertyChanged
    {
        private int? myVar;
        public int? SelectedEntity
        {
            get { return myVar; }
            set { myVar = value; OnPropChanged("SelectedEntity"); }
        }
        
        public Window1()
        {
            InitializeComponent();
            myEntityComboBox.ItemsSource = new[]
            {
                new { myEntityId = (int?)null, myEntityName="Null Option"},
                new { myEntityId = (int?)1, myEntityName="#1"},
                new { myEntityId = (int?)2, myEntityName="#2"}
            };
            myEntityComboBox.SelectedIndex = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void myEntityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myEntityComboBox.SelectedIndex = 0;
        }
    }
    public class NonNullValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            return value == null
                ? new ValidationResult(false, "Gruu!")
                : new ValidationResult(true, null);
        }
    }    
