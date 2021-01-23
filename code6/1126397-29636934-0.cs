    private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 1)
            {
                //Retrieves the first cell selected
                var startRow = dataGridView1.SelectedCells[dataGridView1.SelectedCells.Count - 1].RowIndex;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    if (cell.RowIndex != startRow)
                    {
                        cell.Selected = false;
                    }
                }
            }
        }
