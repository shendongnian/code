    public struct slqParameters
    {
          
        public object ParamData { get; set; }
        public string ParamKey { get; set; }
        public SqlDbType ParamDatabaseType { get; set; }
        public int ParamSize { get; set; }
    }
    
    class db
    {
        private string connectionString = ("connection string will be here...");
    
        public static void ExecuteStoreProcedure(string ProcedureName, ref slqParameters[]  CommandParameters)
         {
             string str_ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
             try
             {
                 using (SqlConnection sqlConnection = new SqlConnection(str_ConnectionString))
                 {
                     using (SqlCommand sqlCommand = new SqlCommand(sProcedureName, sqlConnection) { CommandType = CommandType.StoredProcedure })
                     {
                         // Add all the parameters to the sql command.
                         foreach (slqParametersParameter in CommandParameters)
                         {
                             // Add a parameter
                             sqlCommand.Parameters.Add(new SqlParameter(Parameter.ParamKey, Parameter._ParamDatabaseType , Parameter._ParamSize ) { Value = Parameter.ParamData  });
                            }
                            sqlConnection.Open();
                            DataTable dtTable = new DataTable();
                            sqlCommand.ExecuteReader())
                        }
                    }
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
    }
