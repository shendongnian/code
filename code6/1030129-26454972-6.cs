    public partial class Form1 : Form
    {
           
        public Form1()
        {
            InitializeComponent();
            this.InitializeDataObjects();
        }
        private void InitializeDataObjects()
        {
            this.InitData();
            this.InitBindingSources();
        }
        private void InitData()
        {
            ds = new DataSet();
            var dt = new DataTable("Table1");
            dt.Columns.Add("Name", typeof(string));
            ds.Tables.Add(dt);
        }
        private void InitBindingSources()
        {
            bindingSource1 = new BindingSource();
            bindingSource2 = new BindingSource();
            bindingSource1.DataSource = ds;
            bindingSource1.DataMember = "Table1";
            bindingSource2.DataSource = ds;
            bindingSource2.DataMember = "Table1";
            listBox1.DataSource = bindingSource1;
            listBox1.DisplayMember = "Name";
            listBox2.DataSource = bindingSource2;
            listBox2.DisplayMember = "Name";
        }
    }
