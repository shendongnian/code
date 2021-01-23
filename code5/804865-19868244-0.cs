    //Save the data from the gridviews back to the respective tables
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Declare which tables get updated
            DataTable table1 = alereDataSet.Tables["immaster"];
            DataTable table2 = uPCDataSet.Tables["UPC"];
            DataTable table3 = hangtagDataSet.Tables["upccode"];
            DialogResult dr = MessageBox.Show("Are you sure you want to commit the values to the databases?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
                try
                {
                    //Update immaster with the modified data
                    immasterTableAdapter.Update(table1.Select(null, null, DataViewRowState.ModifiedCurrent));
                    dataGridView1.Refresh();
                    //Insert a new row in the upccode table with the values from the cells in the last row
                    upccodeTableAdapter.Insert(dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0].Value.ToString(), dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[1].Value.ToString(), ("Added " + System.DateTime.Now));
                    dataGridView3.Refresh();
                    //Insert a new row in UPC table with the values from the cells in the last row
                    uPCTableAdapter.Insert(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[3].Value.ToString(), dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[2].Value.ToString(), dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[0].Value.ToString(), dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[1].Value.ToString());
                    dataGridView2.Refresh();
                    clearTextboxes();
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
        }
