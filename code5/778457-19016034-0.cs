    public partial class CalendarTable_Stage1 : Form
    {
        public CalendarTable_Stage1()
        {
            InitializeComponent();
            this.Controls.Add(makeDGV(DT));
        }
        DataTable DT
        {
            get
            {
                //Sample DataTable
                DataTable dtb = new DataTable();
                dtb.Columns.Add("empName");
                dtb.Columns.Add("empAddress");
                dtb.Rows.Add("Salim", "S.10, Santhi Nagar, Palakkad");
                dtb.Rows.Add("Manaf", "Thriveni, English church road, Palakkad");
                dtb.Rows.Add("Mohsin Khan", "Civil Nagar, Palakkad");
                return dtb;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        DataGridView makeDGV(DataTable dt)
        {
            DataGridView dgv = new DataGridView();
            // set dgv properties
            dgv.Size = new Size(300, 400);
            dgv.Columns.Add("empName", "Name");
            
            DataGridViewLinkColumn linkCol = new DataGridViewLinkColumn();
            linkCol.HeaderText = "Address";
            linkCol.Name = "empAddress";
            dgv.Columns.Add(linkCol);
            dgv.AllowUserToAddRows = false; // This will greatly increase adding speed
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);
            foreach (DataRow row in dt.Rows)
            {
                DataGridViewLinkCell_Mine linker = new DataGridViewLinkCell_Mine();
                linker.Value = "Copy";
                linker.data = row[1].ToString();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = row[0].ToString();
                dgv.Rows.Add();
                if (!dgv.AllowUserToAddRows)
                {
                    dgv[0, dgv.Rows.Count - 1] = cell;
                    dgv[1, dgv.Rows.Count - 1] = linker;
                }
                else
                {
                    dgv[0, dgv.Rows.Count - 2] = cell;
                    dgv[1, dgv.Rows.Count - 2] = linker;
                }
            }
            return dgv;
        }
        class DataGridViewLinkCell_Mine : DataGridViewLinkCell
        {
            public string data = "";
        }
        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewLinkCell_Mine cell = (DataGridViewLinkCell_Mine)dgv[e.ColumnIndex, e.RowIndex];
                Clipboard.SetText(cell.data);
                MessageBox.Show(Clipboard.GetText());
            }
        }
    }
