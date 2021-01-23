    public partial class Window1 : Window
    {
        public ObservableCollection<Employee> empList { get; set; }
        public Window1()
        {
            InitializeComponent();
            empList = new ObservableCollection<Employee>();
            empList.Add(new Employee("John", "Michael"));
            empList.Add(new Employee("Freddy", "Rajec"));
            this.DataContext = this;//important line, wihtout this line your window will not get access to objects
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Employee(string sName, string sSurname)
        {
            Name = sName;
            Surname = sSurname;
        }
    }
