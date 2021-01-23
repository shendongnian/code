    decimal total2014  = 0;
    decimal total2015  = 0;
    decimal difference = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total2014  += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total2014"));
            total2015  += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total2015"));
            difference += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Difference"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridView1.FooterRow.Cells[1].Text = String.Format("{0:c}", total2014);
            GridView1.FooterRow.Cells[2].Text = String.Format("{0:c}", total2015);
            GridView1.FooterRow.Cells[3].Text = String.Format("{0:c}", difference);
        }
    }
