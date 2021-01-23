            var emlLevel = levelValue;
            var emlStat = statValue;
            using (SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetEmailList";
                    cmd.Parameters.Add(new SqlParameter("eml_level", emlLevel));
                    cmd.Parameters.Add(new SqlParameter("eml_level", emlStat));
                    sqlConn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        /* do whatever you need with the dr result */
                    }
                    
                    /* clean up*/
                }
            }
