    using (SqlConnection dbConnection = new SqlConnection("CONNECTIONSTRING"))
                //Create database connection  
                {
                    // Database command with stored - procedure  
                    using (SqlCommand dbCommand =
                           new SqlCommand("SP_INSERT_BULK", dbConnection))
                    {
                        // we are going to use store procedure  
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        // Add input parameter and set its properties.
                        SqlParameter parameter = new SqlParameter();
                        // Store procedure parameter name  
                        parameter.ParameterName = "@DataXML";
                        // Parameter type as XML 
                        parameter.DbType = DbType.Xml;
                        parameter.Direction = ParameterDirection.Input; // Input Parameter  
                        parameter.Value = xmlstring; // XML string as parameter value  
                        // Add the parameter in Parameters collection.
                        dbCommand.Parameters.Add(parameter);
                        dbConnection.Open();
                        int intRetValue = dbCommand.ExecuteNonQuery();
                    }
                }
