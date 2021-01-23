    protected void Page_Load(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["LgnConnectionString"].ConnectionString;
    string str;
        SqlCommand com;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        str = "select top 5 Title from table ORDER BY Datetime DESC";
        com = new SqlCommand(str, con);
        SqlDataReader reader;
        reader = com.ExecuteReader();
        //world_rep.DataSource = reader;
        //world_rep.DataBind();
        article_rep.DataSource = reader;
        article_rep.DataBind();
        con.Close();
    }
