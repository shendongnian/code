    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DeleteCellsIfNotInEditMode();
    }
    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            DeleteCellsIfNotInEditMode();
        }
    }
    private void DeleteCellsIfNotInEditMode()
    {
        if (!dataGridView1.CurrentCell.IsInEditMode)
        {
            foreach (DataGridViewCell selected_cell in dataGridView1.SelectedCells)
            {
                selected_cell.Value = "";
            }
        }
    }
