    Int32 tot = 0; 
    protected void Dg_Source_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tot = tot + Convert.ToInt32(e.Row.Cells[1].Text);
                lblSum.Text = tot.ToString();
            }
    
        }
