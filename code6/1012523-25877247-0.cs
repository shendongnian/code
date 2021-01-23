    protected string InjectUpdateToProductDBString(string Command, TextBox Data, string TBColumn)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AuthenticationDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(command, con))
            {
                cmd.Parameters.AddWithValue("@" + TBColumn, Data.Text.ToString());
                cmd.ExecuteNonQuery();
            }
        }
        return "Data successfully updated";
    }
