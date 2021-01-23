    void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
      var cb = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
      if (cb != null && !cb.Items.Contains(e.FormattedValue)) {
        cb.Items.Add(e.FormattedValue);
        if (dgv.IsCurrentCellDirty) {
          dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.FormattedValue;
      }
    }
