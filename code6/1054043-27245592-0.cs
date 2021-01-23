    if (e.Row.RowType == DataControlRowType.Header)
    {
          e.Row.Cells[3].ColumnSpan = 2;
          e.Row.Cells[4].Visible = false;
          e.Row.Cells[3].Text = "Action";
    }
