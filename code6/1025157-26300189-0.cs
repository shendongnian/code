     private void btnCrudSearch_Click(object sender, EventArgs e)
        {
            
            dgvLoadTable.CurrentCell = null;
            dgvLoadTable.AllowUserToAddRows = false;
            dgvLoadTable.ClearSelection();
            dgvLoadTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoadTable.ReadOnly = true;
           
            try
            {
                foreach (DataGridViewRow row in dgvLoadTable.Rows)
                {
                    var cellValue = row.Cells[cboCrudSearchColumn.SelectedIndex].Value;
                    if (cellValue != null && cellValue.ToString() == txtCrudSearch.Text.ToUpper())
                    {
                        row.Selected = true;
                        row.Visible = true;
                    }
                    else
                        row.Visible = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
