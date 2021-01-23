    private void datagridview_ColumnDividerDoubleClick(object sender, DataGridViewColumnDividerDoubleClickEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        datagridview.AutoResizeColumn(e.ColumnIndex, DataGridViewAutoSizeColumnMode.DisplayedCells);
      }
      e.Handled = true;
    }
