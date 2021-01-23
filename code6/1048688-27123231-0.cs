    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (GridView1.EditIndex >= 0)
                    return;
    
                if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) &&
                (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header))
                {
                    e.Row.Cells[4].Visible = false;
                }
            }
