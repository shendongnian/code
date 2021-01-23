    public List<String> JSONDataAll()
    {
        List<String> Users = new List<String>();
        using (SqlConnection con = new SqlConnection("connectionString"))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_sample_Proc", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users.Add(reader.GetString(0)); //Specify column index 
                    }
                }
            }
        }
        return Users;
    }
