    protected void Page_Load(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["LgnConnectionString"].ConnectionString;
        string str;
        int requestId = int.Parse(Request.QueryString["id"]); //Get the ID
        SqlCommand com;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        str = "select * from table where ID=@ID";
        com = new SqlCommand(str, con);
        com.parameters.addWithValue("@ID", requestId); //add ID parameter to query
        SqlDataReader reader;
        reader = com.ExecuteReader();
        myDetailsview.DataSource = reader;
        myDetailsview.DataBind();
        con.Close();
    }
