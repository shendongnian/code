    public class MainWindowViewModel : NotificationObject
    {
        public MainWindowViewModel()
        {
            Employees = new ObservableCollection<Employee>
            {
                new Employee { EmployeeName = "Steven"},
                new Employee { EmployeeName = "Josh"},
            };
        }
        public ObservableCollection<Employee> Employees { get; set; }
    }
