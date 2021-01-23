    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.EditingControlShowing +=new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
    
        DataGridViewComboBoxColumn curCol1 = new DataGridViewComboBoxColumn();
        List<string> source1 = new List<string>() { "val1", "val2", "val3" };
        curCol1.DataSource = source1;
        DataGridViewComboBoxColumn curCol2 = new DataGridViewComboBoxColumn();
    
        dataGridView1.Columns.Add(curCol1);
        dataGridView1.Columns.Add(curCol2);
    
        for (int i = 0; i <= 5; i++)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, i].Value = source1[0];
            changeSourceCol2((string)dataGridView1[0, i].Value, (DataGridViewComboBoxCell)dataGridView1[1, i]);
        }
    }
    
    private void changeSourceCol2(string col1Val, DataGridViewComboBoxCell cellToChange)
    {
        if (col1Val != null)
        {
            List<string> source2 = new List<string>() { col1Val + "1", col1Val + "2", col1Val + "3" };
            cellToChange.DataSource = source2;
            cellToChange.Value = source2[0];
        }
    }
    
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentRow != null)
        {
            ComboBox col1Combo = e.Control as ComboBox;
            if (col1Combo != null)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    col1Combo.SelectedIndexChanged += col1Combo_SelectedIndexChanged;
                }
            }
        }
    }
    
    private void col1Combo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == 0)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            changeSourceCol2(dataGridView1.CurrentCell.Value.ToString(), (DataGridViewComboBoxCell)dataGridView1[1, dataGridView1.CurrentCell.RowIndex]);
        }
    }
