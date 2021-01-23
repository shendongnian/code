private void btnDel_Click(object sender, EventArgs e)
        {
            dgvSearchResults.ReadOnly = false;
            if (MessageBox.Show("Delete?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                dgvSearchResults.Rows.RemoveAt(dgvSearchResults.SelectedRows[0].Index);
                
                ole_da.SelectCommand = new OleDbCommand("SELECT * FROM Projects");
                ole_da.SelectCommand.Connection = conn;
                oleCmdBuilder = new OleDbCommandBuilder(ole_da);
                ole_da.Update(dTable);
            }
        }
