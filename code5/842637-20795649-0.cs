    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            if(e.Row.Cells[0].Text =="F")
            {
                e.Row.Cells[0].Text = "CF";
            }
            else if (e.Row.Cells[0].Text == "N")
            {
                e.Row.Cells[0].Text = "CN";
            }
    }
