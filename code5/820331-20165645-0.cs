    int[] TotalStats = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    protected void GridViewHomeTeamStats_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 7; i <= 18; i++)
        {
            // check row type
            if (e.Row.RowType == DataControlRowType.DataRow)
            // if row type is DataRow, add ...                
            {
                TotalStats[i-7] += Convert.ToInt32(e.Row.Cells[i].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
                // If row type is footer, show calculated total value
                e.Row.Cells[i].Text = String.Format("{0:0.##}", TotalStats[i-7]);
        }
    }
