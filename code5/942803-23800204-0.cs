     protected void GetGrid()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from UserDetails", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].Cells[1].Text == "k" && GridView1.Rows[i].Cells[2].Text == "j")
                GridView1.Rows[i].Cells[2].ControlStyle.BackColor = Color.Green;
            else
                GridView1.Rows[i].Cells[2].ControlStyle.BackColor = Color.Red;
        }
    }
