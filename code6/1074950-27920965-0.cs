    //Create comboBox
    DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
    c.Items.Add("A");
    c.Items.Add("B");
    c.Items.Add("C");
    //Assign it to your dataGridView
    yourDataGridView.Rows[rowNum].Cells[colNum] = c;
