    private void btnUpdate_Click(object sender, EventArgs e)
        {
           //Get the selected row
           DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
    
           //Check if Project Name cell in the selected row null or empty
           if (string.IsNullOrWhiteSpace(selectedRow.Cells["ProjectName"].Value.ToString()))
            {
                MessageBox.Show("There are no any records to update");
            }
            else
            {
    
            }                      
        }   
