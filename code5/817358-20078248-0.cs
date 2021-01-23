    namespace Company_Employees
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
        public partial class Form1 : Form
        {
            public List<Employee> Employees { get; set; }
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string name = eName.Text;
                int id;
                int.TryPase(eNum.Text, out id);
                // add whatever validation you need here to ensure values are correct.
                this.Employees.Add(new Employee(name, id);
                eName.Text = string.Empty;
                eNum.Text = string.Empty;
            }
        }
    }
