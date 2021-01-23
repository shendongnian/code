    private string GetUserType(string username, string password)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"]))
        {
            using (SqlCommand cmd = new SqlCommand("select Type from tblAccount where Username = @Username and Password = @Password", con))
            {
                cmd.AddParameter("@Username", username);
                cmd.AddParameter("@Password", password);
                con.Open();
                using (SqlReader dr = cmd.ExecuteReader())
                {
                    return (dr.Read()) ? dr[0] as string : return null;
                }
            }
        }
    }
