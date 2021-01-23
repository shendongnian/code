    public partial class WPFDataGridComboBox : Window
    {
        public List<Employee> Employees { get; set; }
        public List<string> Genders { get; set; }
        public WPFDataGridComboBox()
        {
            Employees = new List<Employee>()
            {
                new Employee() { Name = "ABC", Gender = "Female" },
                new Employee() { Name = "XYZ" }
            };
            Genders = new List<string>();
            Genders.Add("Male");
            Genders.Add("Female");
            InitializeComponent();
            myGrid.ItemsSource = Employees;
            Gender.ItemsSource = Genders;
        }
        private void ShowPersonDetails_Click(object sender, RoutedEventArgs e)
        {
            foreach (Employee employee in Employees)
            {
                string text = string.Empty;
                text = "Name : " + employee.Name + Environment.NewLine;
                text += "Gender : " + employee.Gender + Environment.NewLine;
                MessageBox.Show(text);
            }
        }
    }
