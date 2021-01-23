    class StoredProc
    {
        public void ToTheDB(EndUser endUser, Company company, Bank bank)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("Procedure",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Here you can use data from your "model" classes and add them as parameters for your stored procedure.
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = endUser.firstName;
                    //the rest of the parameters from EndUser, Company and Bank classes
    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
