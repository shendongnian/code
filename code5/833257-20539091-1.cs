    Keyboard.Focus (GetDataGridCell (dataGridFiles.SelectedCells[0]));
    private System.Windows.Controls.DataGridCell GetDataGridCell (System.Windows.Controls.DataGridCellInfo cellInfo)
    {
      var cellContent = cellInfo.Column.GetCellContent (cellInfo.Item);
      if (cellContent != null)
        return ((System.Windows.Controls.DataGridCell) cellContent.Parent);
      return (null);
    }
