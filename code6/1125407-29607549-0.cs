    if(IsPostBack)
    {
       SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["regConnectionString"].ConnectionString);
       conn.Open();
       string checkuser = "SELECT TOP 1 username FROM users WHERE username='"+ Usernametxt.Text +"'";
       SqlCommand com = new SqlCommand(checkuser, conn);
       string temp = com.ExecuteScalar().ToString();
       if (!string.IsNullOrEmpty(temp))
       {
           Response.Write("User already exists");
       }
       conn.Close();
    }
