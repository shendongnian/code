    void AddBank(Bank bank)
    {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString))
            {
                con.Open();
                //Procedure for inserting
                using(SqlCommand cmd = new SqlCommand("Procedure",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = bank.name;
                    cmd.ExecuteNonQuery();
                }
            }
    }
