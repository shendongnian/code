    static int totSubTot = 0; 
    static double TotalAmount; 
    protected void gvShowOrder_RowDataBound(object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            totSubTot += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SubTotal"));        
        } else if (e.Row.RowType == DataControlRowType.Footer) {
            e.Row.Cells[2].Text = "Grand Total";
            e.Row.Cells[2].Font.Bold = true;
 
            e.Row.Cells[3].Text = totSubTot.ToString();
            e.Row.Cells[3].Font.Bold = true;
            TotalAmount = Convert.ToDouble(e.Row.Cells[3].Text);
        }
    }
