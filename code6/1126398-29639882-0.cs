    private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
    {
      if ((e.StateChanged == DataGridViewElementStates.Selected) && // Only handle it when the State that changed is Selected
          (dataGridView1.SelectedCells.Count > 1))
      {
        // A LINQ query on the SelectedCells that does the same as the for-loop (might be easier to read, but harder to debug)
        // Use either this or the for-loop, not both
        if (dataGridView1.SelectedCells.Cast<DataGridViewCell>().Where(cell => cell.RowIndex != e.Cell.RowIndex).Count() > 0)
        {
          e.Cell.Selected = false;
        }
        /*
        foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
        {
          if (cell.RowIndex != e.Cell.RowIndex)
          {
            e.Cell.Selected = false;
            break;  // stop the loop as soon as we found one
          }
        }
        */
      }
    }
