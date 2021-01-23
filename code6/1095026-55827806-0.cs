    if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
                /taking the index of the selected rows and removing/
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else//optional
            {
                MessageBox.Show("Pleasse Select a Row");
            }
    
