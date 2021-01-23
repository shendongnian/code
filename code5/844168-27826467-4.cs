         String conn = System.Configuration.ConfigurationManager.ConnectionStrings["CONSTRING"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter da = new SqlDataAdapter("select Code from table1", con);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                con.Close();
                ddl.DataSource = ds.Tables[0];
                ddl.DataValueField = "Code";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-- select --"));
            }
        }
