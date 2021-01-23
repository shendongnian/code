    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Check the status here
                if (status == "ready")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                }
            }
        }
