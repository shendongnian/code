    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           foreach (DataControlFieldCell cell in e.Row.Cells)
           {
              string cellVal = cell.Text;
           }
        }
     }
