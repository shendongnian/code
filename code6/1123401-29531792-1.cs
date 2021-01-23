            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
          
                //Checking the RowType of the Row  
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime firsDateValue = Convert.ToDateTime(e.Row.Cells[1].Text);
                    DateTime secondDateValue = Convert.ToDateTime(e.Row.Cells[2].Text);
                    TimeSpan timespan = secondDateValue - firsDateValue;
                    if (timespan.Hours > 2)
                    {
                        e.Row.BackColor = Color.Cyan;
                    }
                }
            } 
