     private void btnShowForm2_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                selectedRows.Add(row);
            }
            Form2 oForm = new Form2(this);
            oForm.Rows = selectedRows;
            oForm.Show();
        }
