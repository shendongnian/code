    string sqlStmt = "SELECT name FROM sys.identity_columns " +
                     "WHERE object_id = OBJECT_ID(@TableName)";
    using (SqlConnection conn = new SqlConnection(your-connection-string-here))
    using (SqlCommand cmd = new SqlCommand (sqlStmt, conn))
    {
         // add table name as parameter
         cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 100).Value = name[i];
 
         // open, execute, close
         conn.Open();
         object result = cmd.ExecuteScalar();
         conn.Close();
         // if result is NULL --> no identity column
         if (result != null) 
         {
              string identityColumn = result.ToString();
         }
    }
