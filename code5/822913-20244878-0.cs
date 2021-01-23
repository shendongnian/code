    //CellClick event handler for your dgvHistory
    private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e){
      var bounds = dgvHistory.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
      dgvHistory.Controls.Add(pnl);
      pnl.Location = new Point(0,bounds.Bottom);
      pnl.BringToFront();
    }
