    string searchValue = textBox1.Text;
    
    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    try
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.Cells[2].Value.ToString().Equals(searchValue))
            {
                row.Selected = true;
            }
            else
            {
                dataGridView1.Rows.RemoveAt(row.Index); //Remove
            }
        }
    }
    catch (Exception exc)
    {
        MessageBox.Show(exc.Message);
    }
