    public class Customer
    {
        string name;
        int age;
        public Customer(string thename, int theage)
        {
            name = thename;
            age = theage;
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    public class ChildForm : Form
    {
        DataGridView dataGridView1 = new DataGridView();
        public ChildForm()
        {
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(dataGridView1);
            dataGridView1.Dock = DockStyle.Fill;
        }
        public void AddData(List<Customer> theData)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = theData;
        }
    }
    public class ParentForm : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }
        DataGridView dataGridView1 = new DataGridView();
        Button button1 = new Button();
        ChildForm childForm = new ChildForm();
        public ParentForm()
        {
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(dataGridView1);
            this.Controls.Add(button1);
            this.Load += new EventHandler(ParentForm_Load);
            button1.Click += new EventHandler(button1_Click);
            button1.Dock = DockStyle.Top;
            button1.Text = "CopyToChild";
            dataGridView1.Dock = DockStyle.Fill;
        }
        void button1_Click(object sender, EventArgs e)
        {
            List<Customer> customers = new List<Customer>();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                Customer customer = row.DataBoundItem as Customer;
                if (customer != null)
                {
                    customers.Add(customer);
                }
            }
            childForm.AddData(customers);
        }
        private void ParentForm_Load(object sender, EventArgs e)
        {
           
            System.Collections.ArrayList customers = new System.Collections.ArrayList();
            customers.Add(new Customer("Thor", 120));
            customers.Add(new Customer("Loki", 110));
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = customers;
            childForm.Show();
        }
    }
