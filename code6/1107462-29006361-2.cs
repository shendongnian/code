    public partial class UcRowDisplay : UserControl
    {
        public UcRowDisplay()
        {
            InitializeComponent();
        }
        private void UcRowDisplay_Load(object sender, EventArgs e)
        {
        }
        public void displayRowData(DataGridViewRow row)
        {
            label1.Text = row.Cells[1].Value.ToString();
            label2.Text = row.Cells[0].Value.ToString();
        }
    }
