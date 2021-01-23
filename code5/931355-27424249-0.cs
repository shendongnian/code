     protected void grdSearchResults_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {    
                    if (e.Row.Cells[1].Text == "Closed")
                    {
                        e.Row.ForeColor = System.Drawing.Color.LightGray;
    
                        for (int i = 0; i < grdSearchResults.Columns.Count; i++)
                        {
                            e.Row.Cells[i].BorderColor = System.Drawing.Color.Black;
                        }                 
                    }    
                }
            }
