    public partial class MainWindow : Window
    {
        private List<Employee> _lstEmployees;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _lstEmployees = new List<Employee>();
            _lstEmployees.Add(new Employee { Name = "Goutham", EmployeeId = "da", Destination = "dar" });
            _lstEmployees.Add(new Employee { Name = "Adam", EmployeeId = "dwa", Destination = "ads" });
            _lstEmployees.Add(new Employee { Name = "dwad", EmployeeId = "daw", Destination = "wadwa" });
            lbEmployee.ItemsSource = _lstEmployees;
        }
    }
    public class EmployeeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string name;
            switch ((string)parameter)
            {
                case "FormatEmployee":
                    if (values[0] is String)
                    { 
                        name = values[0] + ", " + values[1] + ", " + values[2]; 
                    }
                    else
                    {
                        name = String.Empty;
                    }
                    break;
                default:
                    name = String.Empty;
                    break;
            }
            return name;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] splitValues = ((string)value).Split(' ');
            return splitValues;
        }
    }
