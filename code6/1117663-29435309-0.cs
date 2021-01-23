    int temp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssignmentDBConnectionString"].ConnectionString);
            conn.Open();
            string checkUser = "select count(*) from [AsTable] where Username ='" + TextBoxUsername.Text + "'";
            SqlCommand com = new SqlCommand(checkUser, conn);
            com.ExecuteNonQuery();
            temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp != 0)
            {
                Response.Write("User Already Exists");
            }
            conn.Close();
        }
    }
     .
     .
