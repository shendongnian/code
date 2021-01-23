    using( System.Data.Common.DbConnection conn = new System.Data.SqlClient.SqlConnection("<<connection string>>)
    {
         using(System.Data.Common.DbCommand cmd = conn.CreateCommand())
         {
             cmd.CommandType = <Choose either TEXT or StoredProcedure>;
             cmd.Text = "<T-SQL or name of sproc:"dbo.ProcedureName">;
             using( System.Data.Common.DbDataReader rdr = cmd.ExecuteReader() )
             {
                  //if only reading 1 row
                  if( rdr.Read() )  // the .Read() method will read row by row
                  {
                     
                      string s = (string) rdr["Column"];  //<-- best to always check for nulls.
                  }
             }
    }
