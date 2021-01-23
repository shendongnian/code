    public partial class Form1 : Form
    {
        public class Employee
        {
            public string Name { get; set; }
            public int Id { get; set; }
    
            public Employee(string name, int id)
            {
                this.Name = name;
                this.Id = id;
            }
        }
        public List<Employee> Employees { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.CreateEmployee();
        }
        private bool EmployeeValuesAreValid(string name, int id)
        {
            return !String.IsNullOrEmpty(name) && id > 0;
        }
        private void CreateEmployee()
        {
            // Get textbox values.
            string name = eName.Text;
            int id;
            int.TryParse(eNum.Text, out id);
            // Validate the values to make sure they are acceptable before storing.
            if (this.EmployeeValuesAreValid(name, id))
            {
                // Values are valid, create and store Employee.
                this.Employees.Add(new Employee(name, id));
                // Clear textboxes.
 
                eName.Text = string.Empty;
                eNum.Text = string.Empty;
            }
        }
    }
