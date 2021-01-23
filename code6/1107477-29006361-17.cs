    public partial class UcRowDisplay : UserControl
    {
        public UcRowDisplay()
        {
            InitializeComponent();
        }
        public delegate void someActionDelegate(DataGridViewRow row);
        public someActionDelegate button1Action { get; set; } 
        DataGridViewRow  myRow = null;
        public void displayRowData(DataGridViewRow row)
        {
            myRow  = row;
            label1.Text = row.Cells[1].Value.ToString();
            label2.Text = row.Cells[0].Value.ToString();
            rowDisplayBtn1.Text = row.Cells[2].Value.ToString();
        }
        private void rowDisplayBtn1_Click(object sender, EventArgs e)
        {
            button1Action(myRow);
        }
        private void label_X_Click(object sender, EventArgs e)
        {
            myRow.Selected = false;
            this.Hide();
        } 
    }
