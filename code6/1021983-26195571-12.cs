    public partial class DataForm : UserControl
    {
        public DataTable theTable { get; set; }
        public DataForm()
        {
            InitializeComponent();
        }
         public int  showRow(int rowIndex)
         {
             if (theTable == null) return -1;
             if (theTable.Rows.Count < rowIndex) return -2;
             DataRow row = theTable.Rows[rowIndex];
             label1.Text = row[0].ToString();
             label2.Text = row[1].ToString();
             label3.Text = row[2].ToString();
             return 0;
         }
    }
