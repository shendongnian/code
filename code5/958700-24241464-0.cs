	DataSet dataToReturn = null;  DataSet dataToReturn = null;
                    using (var temp = new DataSet())
                    {
                        var useFederationCommandText = BuildUSEFederation(fedID);
                        using (var connection = new SqlConnection(ATCommon.DSN))
                        {
                            connection.Open();
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = useFederationCommandText;
                                command.ExecuteNonQuery();
                            }
                            SqlParameter[] sqlparams = {
                                 new SqlParameter("@USERID",userId), 
                                 new SqlParameter("@BASESTARTDATE",baseStartDate), 
                                 new SqlParameter("@BASEENDDATE",baseEndDate),
                                 new SqlParameter("@CASETYPEID",caseType), 
                                 new SqlParameter("@GROUPTYPE",groupType)
                                    };
                            using (var dataAdapter = new SqlDataAdapter())
                            {
                                using (var command = new SqlCommand("TrendUserGraphTest"))
                                {
                                    foreach (var param in sqlparams)
                                    {
                                        command.Parameters.Add(param);
                                    }
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Connection = connection;
                                    //command.CommandText = strSql;
                                    dataAdapter.SelectCommand = command;
                                    dataAdapter.Fill(temp);
                                }
                            }
                        }
                        dataToReturn = temp;
                    }
	
