    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gv2 = (GridView)e.Row.FindControl("GridView2");
            string connString = @"your connection string here";
            string query = "select * from dbo.task where PO_ID = " + e.Row.Cells[0].Text;
            SqlConnection conn = new SqlConnection(connString);        
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            gv2.DataSource = dt;
            gv2.DataBind();
        }
    }
