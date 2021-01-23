    public partial class Form1 : Form
    {
        private DataTable _dataSource1;
        private DataTable _dataSource2;
        public Form1()
        {
            InitializeComponent();
            _dataSource1 = GetData1();
            _dataSource2 = GetData2();
            Initialize();
        }
        private void btnMove_Click(object sender, EventArgs e)
        {
            MoveItem();
        }
        void Initialize()
        {
            listBox1.DataSource = _dataSource1;
            listBox1.DisplayMember = "Fruits";
            listBox1.ValueMember = "Fruits";
            
            listBox2.DataSource = _dataSource2;
            listBox2.DisplayMember = "Fruits";
            listBox2.ValueMember = "Fruits";
        }
        DataTable GetData1()
        {
            var dt = new DataTable();
            dt.Columns.Add("Fruits");
            dt.Rows.Add(new object[] {"Apple"});
            dt.Rows.Add(new object[] { "Orange" });
            dt.Rows.Add(new object[] { "Grapes" });
            return dt;
        }
        DataTable GetData2()
        {
            var dt = new DataTable();
            dt.Columns.Add("Fruits");
            return dt;
        }
        void MoveItem()
        {
            var index = listBox1.SelectedIndex;
            var dataRowToRemove = _dataSource1.Rows[index];
            var listItem = dataRowToRemove[0] as string;
            _dataSource1.Rows.Remove(dataRowToRemove);
            var dataRowToAdd = _dataSource2.NewRow();
            dataRowToAdd[0] = listItem;
            _dataSource2.Rows.Add(dataRowToAdd); 
            Initialize();
        }
      
    }
