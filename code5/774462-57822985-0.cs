    private static SqlConnection getConnectionString() // Should be gotten from config in secure storage.
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "it.hurts.when.IP";
                builder.UserID = "someDBUser";
                builder.Password = "someDBPassword";
                builder.InitialCatalog = "someDB";
                return new SqlConnection(builder.ConnectionString);
            }
    
            public static List<T> ExecuteSP<T>(string SPName, List<SqlParameter> Params)
            {
                try
                {
                    DataTable dataTable = new DataTable();
    
                    using (SqlConnection Connection = getConnectionString())
                    {
                        // Open connection
                        Connection.Open();
    
                        // Create command from params / SP
                        SqlCommand cmd = new SqlCommand(SPName, Connection);
    
                        // Add parameters
                        cmd.Parameters.AddRange(Params.ToArray());
                        cmd.CommandType = CommandType.StoredProcedure;
    
                        // Make datatable for conversion
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dataTable);
                        da.Dispose();
    
                        // Close connection
                        Connection.Close();
                    }
    
                    // Convert to list of T
                    var retVal = ConvertToList<T>(dataTable);
                    return retVal;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ConvertToList Exception: " + e.ToString());
                    return new List<T>();
                }
            }
    
            /// <summary>
            /// Converts datatable to List<someType> if possible.
            /// </summary>
            public static List<T> ConvertToList<T>(DataTable dt)
            {
                try // Necesarry unfotunately.
                {
                    var columnNames = dt.Columns.Cast<DataColumn>()
                        .Select(c => c.ColumnName)
                        .ToList();
    
                    var properties = typeof(T).GetProperties();
    
                    return dt.AsEnumerable().Select(row =>
                        {
                            var objT = Activator.CreateInstance<T>();
    
                            foreach (var pro in properties)
                            {
                                if (columnNames.Contains(pro.Name))
                                {
                                    if (row[pro.Name].GetType() == typeof(System.DBNull)) pro.SetValue(objT, null, null);
                                    else pro.SetValue(objT, row[pro.Name], null);
                                }
                            }
    
                            return objT;
                        }).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to write data to list. Often this occurs due to type errors (DBNull, nullables), changes in SP's used or wrongly formatted SP output.");
                    Console.WriteLine("ConvertToList Exception: " + e.ToString());
                    return new List<T>();
                }
            }
