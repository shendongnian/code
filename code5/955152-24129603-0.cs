    private void GetGeneralData( ReportPackage myPackage )
    {
      using ( SqlConnection conn = new SqlConnection(mySqlConn) )
      using ( SqlCommand    cmd  = conn.CreateCommand() )
      {
          cmd.CommandType = CommandType.StoredProcedure ;
          cmd.CommandText = "dbo.GetStuff" ;
          cmd.Parameters.AddWithValue("@id", myPackage.IdDeliverable);
          
          conn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            dr.Read();
            myPackage.DeployServer = dr.GetString(0);
            myPackage.Connection   = dr.GetString(1);
          }
      }
       return ;
    }
