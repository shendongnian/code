    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            // Set the capacity label text
    
            sum += Decimal.Parse(e.Row.Cells[4].Text);
    
        }
    }
