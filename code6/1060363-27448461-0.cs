    string UpdateSQLstring="UPDATE ..."
            SqlClient.SqlParameter  params[2];
            params[0] = new SqlClient.SqlParameter("@input1", SqlDbType.Int);
            params[0].Value =123;
            params[1] = new SqlClient.SqlParameter("@input2",SqlDbType.String);
            params[1].Value = "abc";
        	SqlClient.SqlCommand myCMD=New SqlClient.SqlCommand(UpdateSQLstring, connection)
          myCMD.Parameters.Add(params[0]);
          myCMD.Parameters.Add(params[1]);
          myCMD.ExecuteNonQuery
