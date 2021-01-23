     public partial class Form1 : Form
    {
        DataSet dSet = new DataSet();
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.RowStateChanged += dataGridView1_RowStateChanged;
            dSet = fillDataSet();
            dataGridView1.DataSource = dSet.Tables[0].DefaultView;
            dSet.Tables[0].Rows.Add();
        }
        void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 1];
            dataGridView1.BeginEdit(false);
        }
        DataSet fillDataSet()
        {
            DataSet dSet = new DataSet();
            dSet = new DataSet();
            DataTable table = new DataTable("Names");
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Gender");
            table.Rows.Add(new object[] { 1, "Salim", "Male" });
            table.Rows.Add(new object[] { 2, "Salim", "Male" });
            table.Rows.Add(new object[] { 3, "Salim", "Male" });
            table.Rows.Add(new object[] { 4, "Salim", "Male" });
            table.Rows.Add(new object[] { 5, "Salim", "Male" });
            table.Rows.Add(new object[] { 6, "Salim", "Male" });
            table.Rows.Add(new object[] { 7, "Salim", "Male" });
            table.Rows.Add(new object[] { 8, "Salim", "Male" });
            dSet.Tables.Add(table);
            return dSet;
        }
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dSet.Tables[0].Columns.Count - 1)dSet.Tables[0].Rows.Add();
        }
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                String ssNair = e.StateChanged.ToString();
                if (e.Row.Index > 0)
                    dataGridView1.Rows[e.Row.Index - 1].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[e.Row.Index].DefaultCellStyle.BackColor = Color.Yellow;
            }
            catch { }
        }
    }
