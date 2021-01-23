     private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            object tempObj = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            //dataGridView1_CurrentCellDirtyStateChanged(sender, e);
            if (((e.ColumnIndex) == 1) && ((bool)dataGridView1.Rows[e.RowIndex].Cells[1].Value))
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                splitContainer5.Panel2.Controls["textbox" + e.RowIndex.ToString()].Enabled = true;
                splitContainer5.Panel2.Controls["textbox" + e.RowIndex.ToString()].BackColor = Color.White;
            }
        }
