     using(SqlConnection con= new SqlConnection(your_Connection_String))
     {
        using(SqlCommmand cmd = new SqlCommand())
        {
            cmd.CommandType = CommandType.Text/StoredProcedure; // it depends on what you are using
            cmd.Connection = con;
            cmd.CommandText=Your Query or Name of SP;
            con.Open();
            CreateParameterList(ref s, ref cmd);
            try
            {
              int i = cmd.ExecuteNonQuery();
              if(i>0)
              {
                  //Show Success or return Success
               }
            
              
            }
            catch(SqlException sqlex)
            {
                //catch and log exception
            }
            finally
            {  con.Close(); con.Dispose() }
        }
      }
