    private void dataGridView1_RowHeaderMouseClick (object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            foreach(DataGridViewCell cell in this.dataGridView1.CurrentRow.Cells)
            {
                cell.Selected = true;
            }
        }
