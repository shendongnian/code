    protected void GridView_RowDataBound(object o, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
         e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
      }
    }
