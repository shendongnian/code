    public partial class Form1 : Form
    {
        public CustomerContractsViewModel ContractsVM { get; set; }
        public Form1()
        {
            InitializeComponent();
            ContractsVM  = new CustomerContractsViewModel();
            
            var customercontractsview = new CustomerContractsView(){DataContext = ContractsVM};
            var elementHost = new ElementHost() { Dock = DockStyle.Fill };
            elementHost.Child = customercontractsview;
            panel1.Controls.Add(elementHost);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ContractsVM.LoadCustomers(DataSource.GetCustomers());
        }
    }
