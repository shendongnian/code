     protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
      {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label a = e.Row.FindControl("Label1") as Label;
            if (a != null)
            {
                DateTime lblDate = Convert.ToDateTime(a.Text);
                if (lblDate <= DateTime.Now.AddDays(15))
                {
                    e.Row.Cells[4].BackColor = Color.Red;
    
                }
                else if (lblDate >= DateTime.Now.AddDays(16) && lblDate <= DateTime.Now.AddDays(30))
                {
                    e.Row.Cells[4].BackColor = Color.Yellow;
    
                }
                else
                {
                    e.Row.Cells[4].BackColor = Color.Blue;
                }
    
            }
        }
    }
