    public LoginInfo LoginIndhold(string username, string password)
    {
     LoginInfo returnValue =  null;
            using( SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
       {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Id FROM users WHERE Username = @Username  AND Password = @Password";
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            conn.Open();
           using(SqlDataReader readerbruger = cmd.ExecuteReader())
           {
            if (readerbruger.Read())
            {
                HttpContext.Current.Session["id"] =     Int32.Parse(readerbruger["id"].ToString());
                returnValue = new LoginInfo { Username= username, Password=  password};
            }
           }
        }
    return returnValue;
    }
