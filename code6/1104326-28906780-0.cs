            List<string> lstString = new List<string>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SomeConnectString"].ConnectionString);
            con.Open();
            using (var command = new SqlCommand("Report_FilterSproc", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lstString.Add(reader["ColumnName"].ToString());
                        //do something here to convert these results to a comma separated list.
                    }
                }
            }
            con.Close();
            string result = string.Join(",", lstString.ToArray());
