     public partial class Form1 : Form
        {
            bool bIsComboBox = false;
            delegate void SetComboBoxCellType(int iRowIndex);
            DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                
                var lines = File.ReadAllLines(@"C:\\1.txt");
                if (lines.Count() > 0)
                {
                    foreach (var columnName in lines.FirstOrDefault()
                        .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        dt.Columns.Add(columnName, typeof(string));
                    }
                    foreach (var cellValues in lines.Skip(1))
                    {
                        var cellArray = cellValues
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                      //  if (cellArray.Length == dataGridView1.Columns.Count)
                            dt.Rows.Add(cellArray);
                    }
                    dataGridView1.DataSource = dt;
    
                }
    
            }
    
    
            private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
    
                if (e.ColumnIndex == this.dataGridView1.Columns["Gender"].Index)
                {
                    this.dataGridView1.BeginInvoke(objChangeCellType, e.RowIndex);
                    bIsComboBox = false;
                }
            }
            private void ChangeCellToComboBox(int iRowIndex)
            {
                if (bIsComboBox == false)
                {
                    DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                    dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    
    
                    dgComboCell.DataSource = dt;
                    dgComboCell.ValueMember = "Gender";
                    dgComboCell.DisplayMember = "Gender";
    
                    dataGridView1.Rows[iRowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex] = dgComboCell;
                    bIsComboBox = true;
                }
            }
