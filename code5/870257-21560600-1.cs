         try
         {
            string value = "text value from your control";
            int numberOfRows = 0;
            
            //For Sql Server Authentication
            string connectionString = 
                    @"server=yourservername;InitialCatalog=yourdatabasename;
                                              User Id=sa;Password=yoursqlserverpassword";
            
             //For Windows Authentication
            string connectionString = 
                    @"server=yourservername;InitialCatalog=yourdatabasename;
                                             Integrated Security=SSPI";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string query = "SELECT * FROM DB WHERE Data=@val";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add(new SqlParameter("@val", value));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numberOfRows += Convert.ToInt32(dr[0].ToString());
                }
            }
         }
         catch(Exception ex)
         {
            //Handle your Error - or show it if required
         }
