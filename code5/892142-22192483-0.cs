    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbltotal= (Label)e.Row.FindControl("lbltotal");
            var allRows = ((DataRowView)e.Row.DataItem).Row.Table.AsEnumerable();
            decimal totalPrice = allRows.Sum(r => r.Field<decimal>("Price"));
            lbltotal.Text = totalPrice.ToString();
        }
    }
