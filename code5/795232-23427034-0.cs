    protected void TableGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowIndex == -1 && e.Row.RowType == DataControlRowType.Header)
       {
          GridViewRow gvRow = new GridViewRow(0, 0, DataControlRowType.DataRow,DataControlRowState.Insert);
          for (int i = 0; i < e.Row.Cells.Count; i++)
          {
             TableCell tCell = new TableCell();
             tCell.Text = "&nbsp;";
             gvRow.Cells.Add(tCell);
             Table tbl = e.Row.Parent as Table;
             tbl.Rows.Add(gvRow);
          }
       }
    }
