    if (e.Row.RowType == DataControlRowType.DataRow)
     {
    
                    if (e.Row.Cells[3].Text.StartsWith("-"))
                    {
    
                        // change the color
                        e.Row.Cells[3].BorderColor = System.Drawing.Color.Black;
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Row.Cells[3].BorderColor = System.Drawing.Color.Black;
                    }
    }
               
 
