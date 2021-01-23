     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Column1" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Column2" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Column3" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Column4" });
    
                for (int i = 0; i <= 4; i++)
                {
                    dataGridView1.Rows.Add();
                }
    
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    RowValueSet(row);
                }
            }
    
            private void RowValueSet(DataGridViewRow row)
            {
                row.Cells["Column1"].Value = "1";
                row.Cells["Column2"].Value = "2";
                row.Cells["Column3"].Value = "3";
                row.Cells["Column4"].Value = "4";
            }
        }
