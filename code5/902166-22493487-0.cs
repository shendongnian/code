    public void AddRow(string lName,List<string> lStyles)
    {
        var dgvRow = new DataGridViewRow();
        
        dgvRow.Cells.Add(new DataGridViewTextBoxCell());
        dgvRow.Cells.Add(new DataGridViewComboBoxCell());
        dgvRow.Cells[0].Value = lName;
        ((DataGridViewComboBoxCell) dgvRow.Cells[1]).DataSource = lStyles;
        dataGridView1.Rows.Add(dgvRow);
    }
