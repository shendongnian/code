    protected void gridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Footer)
        {
          e.Row.Cells[1].Text = sum1.ToString();
          e.Row.Cells[2].Text = sum2.ToString();
        }
    }
