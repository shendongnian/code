     static class Database
     {
         public static Int32 intReturnCode { get; set; }
         public static string DatabaseStatus { get; set; }
         static SqlConnection databaseConnection;
         static SqlCommand sqlCmd_usp_InsertUser;
         static SqlCommand sqlCmd_usp_InitializeDatabase;
         string source = @"Server=MyServer;Database=MyDatabase;Integrated Security=True; Timeout=30";
     
         //static initalizer
         static Database()
         {
             string source = @"Server=MyServer;Database=MyDatabase;Integrated Security=True; Timeout=30";
             databaseConnection = new SqlConnection(source);
     
             // usp_InsertUser
             sqlCmd_usp_InsertUser = new SqlCommand("usp_InsertUser", databaseConnection);
             sqlCmd_usp_InsertUser.CommandType = CommandType.StoredProcedure;
     
             sqlCmd_usp_InsertUser.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NChar, 8) { Direction = ParameterDirection.Input });
             sqlCmd_usp_InsertUser.Parameters.Add(new SqlParameter("@Department", SqlDbType.NChar, 4) { Direction = ParameterDirection.Input });
             sqlCmd_usp_InsertUser.Parameters.Add(new SqlParameter("@ReturnCode", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue });
         }
     
     
         public static void InsertTracking(string UserID, string Department)
         {
             try
             {
                 if (databaseConnection.State != ConnectionState.Open)
                     databaseConnection.Open();
                 sqlCmd_usp_InsertUser.Parameters["@UserID"].Value = UserID;
                 sqlCmd_usp_InsertUser.Parameters["@Department"].Value = Department;
                 sqlCmd_usp_InsertUser.ExecuteNonQuery();
                 intReturnCode = Convert.ToInt16(sqlCmd_usp_InsertUser.Parameters["@ReturnCode"].Value);
                 databaseConnection.Close();
             }
             catch (Exception ex)
             {
                 DatabaseStatus = ex.Message;
             }
         }
     
         public static int InitializeDatabase()
         {
             try
             {
                 SqlCommand cmdSQL = new SqlCommand("usp_InitializeDatabase", databaseConnection);
                 cmdSQL.CommandType = CommandType.StoredProcedure;
                 cmdSQL.Parameters.Add(new SqlParameter("@ReturnCode", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue });
                 
                 if (databaseConnection.State != ConnectionState.Open)
                     databaseConnection.Open();
     
                 cmdSQL.ExecuteNonQuery();
                 intReturnCode = Convert.ToInt16(cmdSQL.Parameters["@ReturnCode"].Value);
     
                 databaseConnection.Close();
             }
             catch (Exception ex)
             {
                 DatabaseStatus = ex.Message;
             }
             return intReturnCode;
         }
     }
     
