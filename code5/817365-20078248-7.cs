    public partial class Form1 : Form
    {
        public List<Employee> Employees { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.CreateEmployee();
        }
    }
