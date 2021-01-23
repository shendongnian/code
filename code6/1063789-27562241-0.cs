    public void show_query(int page)
    {
        conn.Open();
        SqlDataAdapter sda_query = new SqlDataAdapter("select * from query where resolved='NO'", conn);
        DataTable dt = new DataTable();
        sda_query.Fill(dt);
        conn.Close();
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
