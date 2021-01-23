    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(<the info>);
        SqlCommand cmd = new SqlCommand("SELECT * FROM fb_results", conn);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    
        conn.Close();
    }
