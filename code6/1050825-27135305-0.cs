    List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
    void selectRows()
    {
        dataGridView1.SuspendLayout();
        foreach (DataGridViewRow r in dataGridView1.Rows) 
                 r.Selected = selectedRows.Contains(r);
        dataGridView1.ResumeLayout();
    }
    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        DataGridViewRow clickedRow = dataGridView1.CurrentRow;
            
        if (selectedRows.Contains(clickedRow))
            selectedRows.Remove(clickedRow);
        else
            selectedRows.Add(clickedRow);
        selectRows();
    }
