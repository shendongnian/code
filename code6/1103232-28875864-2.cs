    protected void Page_Load(object sender, EventArgs e)
    {
     if (!Page.IsPostBack)
       {
          string strSQLconnection = "Connection to DB";
          SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
    
          SqlCommand sqlCommand = new SqlCommand("Query", sqlConnection);
    
          sqlConnection.Open();
    
          SqlDataReader reader = sqlCommand.ExecuteReader();
    
          GridView1.DataSource = reader;
          GridView1.DataBind();
    
          sqlConnection.Close();
       }
    }
