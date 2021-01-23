    string UpdateSQLstring="UPDATE dbo.IMAGE
                                    SET PIXEL_HEIGHT =@Height ... "
                SqlClient.SqlParameter  params[2];
                params[0] = new SqlClient.SqlParameter("@Height", SqlDbType.Int);
                params[0].Value =100;
                params[1] = new SqlClient.SqlParameter("@Width",SqlDbType.Int);
                params[1].Value = 200;
            	SqlClient.SqlCommand myCMD=New SqlClient.SqlCommand(UpdateSQLstring, connection)
              myCMD.Parameters.Add(params[0]);
              myCMD.Parameters.Add(params[1]);
              myCMD.ExecuteNonQuery
    
    
