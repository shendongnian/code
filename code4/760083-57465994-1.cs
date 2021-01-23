    try
    {
         using (var conn = new SqlConnection(myConnectionString))
         using (var command = new SqlCommand("MyProc", conn)
         {
               CommandType = CommandType.StoredProcedure
         })
         {
              command.Parameters.Add(new SqlParameter("@Arg1", SqlDbType.Structured));
              command.Parameters["@Arg1"].Value = myArgVariable;
              command.Parameters["@Arg1"].TypeName = "dbo.CustomArgType"; 
              conn.Open();
              command.ExecuteNonQuery();
         }
    }
    catch (Exception ex)
    {
         throw;
    }
