    int GetRowIndexFromControl(Control control)
    {
      Table table = null;
      TableRow row = null;
      while(control != null && (table == null || row == null))
      {
        if (row == null) row = control as TableRow;
        if (table == null) table = control as Table;
        control = control.Parent;
      }
      return row == null || table == null ? -1 : table.Rows.GetRowIndex(row);
    }
    protected void btn_Click(object sender, EventArgs e)
    {
      int rowIndex = GetRowIndexFromControl(sender as Control);
      if (rowIndex != -1)
      {
        // Do something with rowIndex
      }
    }
