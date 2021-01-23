    protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack)
           { 
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM myTable",con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
         }
       }
