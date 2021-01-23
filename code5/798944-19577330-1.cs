    using(SqlConnection cn = new SqlConnection(connectionString))
    {
       using(SqlCommand cmd = new SqlCommand(query, cn))
       {
         // define parameters and their values
         cmd.Parameters.Add("@Lastname", SqlDbType.VarChar, 50).Value = txt
         cmd.Parameters.Add("@EmployeeNumber", SqlDbType.VarChar, 50).Value =employeeNumber;
         SqlDataReader reader = null;
         reader = cmd.ExecuteNonQuery();
         DataTable table = new DataTable();
         table.Load(reader);
          if (!reader.IsClosed)
          {
             reader.Close();
          }
          if (table.Rows.Count > 0)
          {
             // redirect 
          }
          else { //error message}
       }
    }
