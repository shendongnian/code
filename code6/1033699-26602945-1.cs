    private void cbHeader_OnCheckBoxClicked(bool _checked)
    {
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            //Give the check box column index instead of 0 in .Cells[0]
            dataGridView1.Rows[i].Cells[0].Value = _checked;
        }
    }
