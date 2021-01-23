    public partial class MainForm : Form
    {
        // this will hold the data for the grid
        List<RowItem> Items = new List<RowItem>();
        public MainForm()
        {
            InitializeComponent();
            gridControl1.DataSource = Items;
            Items.Add(new RowItem() { ID = 1, Caption = "First" });
            Items.Add(new RowItem() { ID = 2, Caption = "Second" });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] filecontents = File.ReadAllBytes(ofd.FileName);
                    // Get the Item object represented by the selected row
                    RowItem selecteditem = gridView1.GetFocusedRow() as RowItem;
                    if (selecteditem == null) return;
                    selecteditem.Bytes = filecontents;
                    selecteditem.FileName = ofd.FileName;
                    gridView1.RefreshData();
                }
            }
        }
    }
    class RowItem
    {
        public int ID { get; set; }
        public string Caption { get; set; }
        public byte[] Bytes { get; set; }
        public string FileName { get; set; }
    }
