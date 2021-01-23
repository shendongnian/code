    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string dateText = ((Label)e.Row.FindControl("Label1")).Text;
            if (!string.IsNullOrEmpty(dateText))
            {
                DateTime dateValue = DateTime.ParseExact(dateText, "MM/dd/yyyy", null);
                if (dateValue <= DateTime.Now.AddDays(15))
                {
                    e.Row.Cells[4].BackColor = Color.Red;
                }
                else if (dateValue >= DateTime.Now.AddDays(16) && dateValue <= DateTime.Now.AddDays(30))
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
