    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // create some items
            itemBindingSource.Add(new Item {Name = "name1", Value = 0});
            itemBindingSource.Add(new Item {Name = "name2", Value = 0.5});
            itemBindingSource.Add(new Item {Name = "name3", Value = 1});
            // find column index to color
            string columnName = "Value";
            int columnIndex = -1;
            DataGridViewColumnCollection columns = itemDataGridView.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                DataGridViewColumn column = columns[i];
                if (column.DataPropertyName == columnName)
                {
                    columnIndex = i;
                    break;
                }
            }
            // color cells
            if (columnIndex >= 0)
            {
                foreach (DataGridViewRow row in itemDataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // get associated data
                        var item = (Item) row.DataBoundItem;
                        // build color from associated data
                        Color fromArgb = Color.FromArgb((int) (item.Value*255), 128, 128);
                        row.Cells[columnIndex].Style.BackColor = fromArgb;
                    }
                }
            }
        }
    }
