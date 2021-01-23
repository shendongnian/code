    private void dtgVOuchers_CellValueChanged(object sender, DataGridViewCellEventArgs e){
      var cell = dtgVOuchers[e.ColumnIndex, e.RowIndex];
      if(cell.OwningColumn.Name == "Rate" || cell.OwningColumn.Name == "Supply"){
        //update the Amount cell
        cell.OwningRow.Cells["Amount"].Value = Convert.ToDecimal(cell.OwningRow.Cells["Rate"].Value) *
                                              Convert.ToDecimal(cell.OwningRow.Cells["Supply"].Value);
      }
    }
