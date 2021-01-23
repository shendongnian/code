    using System.Data;
    using System.Data.SqlClient;
        public static DataSet GetLogin(Int32 userId)
        {
           DataSet logStatusDs = new DataSet();
            //load the List one time to be used thru out the intire application
            var ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["CMSConnectionString"].ConnectionString;
            using (SqlConnection connStr = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("get_LoginStatusQ", connStr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Connection.Open();
                    new SqlDataAdapter(cmd).Fill(logStatusDs);
                }
            }
            return logStatusDs;
        }	
