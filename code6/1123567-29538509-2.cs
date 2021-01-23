    protected void Page_Load(object sender, EventArgs e)
    {                        
        if (!Page.IsPostBack)
        {
            string query = "SELECT * FROM routedoc WHERE Recipient=@user ";
            string user = Session["user"].ToString();
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["imagingConnectionString"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", user);
            con.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            BindDropDown();
        }
     }
