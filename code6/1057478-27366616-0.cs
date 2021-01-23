    private List<int> editedRows = new List<int>;
    private void myDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (!this.editedRows.Contains(e.RowIndex))
      {
         editedRows.Add(e.RowIndex);
      }
    }
