    public partial class MainForm : Form
    {
        private DataForm dataForm = null;
        public MainForm()
        {
            InitializeComponent();
            // init data form
            dataForm = new DataForm();
            dataForm.Init();
        }
        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            // add values
            dataForm.AddRow(new string[] { "10", "20" });
            // show a modal second form, so that the first can not be selected while the second is open!
            dataForm.ShowDialog(this);
        }
    }
	
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }
        // init the grid
        internal void Init()
        {
            this.dataGridView.Columns.Add("A", "A");
            this.dataGridView.Columns.Add("B", "B");
            for (int x = 1; x <= 5; x++)
            {
                string[] row;
                row = new string[] { "1", x.ToString() };
                this.dataGridView.Rows.Add(row);
            }
        }
        // add values to the grid
        public void AddRow(string[] values)
        {
            this.dataGridView.Rows.Add(values);
        }
        // hide second form
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
