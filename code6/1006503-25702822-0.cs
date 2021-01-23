    private void button60_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
        {
            if (oneCell.Selected)
            {
                dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                int loannumber = dataGridView1.Rows[oneCell.RowIndex].Cells['index of loannumber column in datagridview'].Value; // assuming loannmber is integer
                string username = dataGridView1.Rows[oneCell.RowIndex].Cells['index of username column in datagridview'].Value; // assuming username is string
                /* Now create an object of MySqlConnection and MySqlCommand
                 * and the execute following query
                 */
                string query = string.Format("DELETE FROM table_name WHERE loannumber = {0} AND username = '{1}'", loannumber, username);
            }
        }
    
    }
