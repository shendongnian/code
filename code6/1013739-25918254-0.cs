    SqlConnection conn = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand("Your SQL Query", conn);
    conn.Open();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    da.Fill(dt);
    conn.Close();
     
    ListView1.DataSource = dt;
    ListView1.DataBind();
