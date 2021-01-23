     if (IsPostBack)
     {
     int result = 0;
     SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssignmentDBConnectionString"].ConnectionString);
         conn.Open();
    //selects count from userdata and checks if username exists in the database
    string checkUser = "select count(*) from [AsTable] where Username = @username";
    SqlCommand com = new SqlCommand(checkUser, conn);
    com.Parameters.AddWithValue("@username", TextBoxUsername.Text);
    result = (int)com.ExecuteScalar()
    if (result > 0)
    {
        Response.Write("User Already Exists");
    }
    conn.Close();
    }
