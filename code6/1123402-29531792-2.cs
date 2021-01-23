            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                
                //Checking the RowType of the Row  
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime firsDateValue = Convert.ToDateTime(e.Row.Cells[1].Text);
                    DateTime secondDateValue = Convert.ToDateTime(e.Row.Cells[2].Text);
                    long diffInTicks = secondDateValue.Ticks - firsDateValue.Ticks;
                    // Convert ticks into hours, see [Convert datetime Ticks][1] for more details
                    var hours = Math.round((diffInTicks/(60*60*10000000)) % 24); 
                    if (hours > 2)
                    {
                        e.Row.BackColor = Color.Cyan;
                    }
                }
            } 
