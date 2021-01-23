     SQLCmd.CommandText = "some query";
     SQLCmd.Connection = sqlConn;
     sqlConn.Open();
    
    //using will dispose reader automatically.
     using(sqlReader = SQLCmd.ExecuteReader())
    {
       while (sqlReader.Read())
        {
        //some stuff here
        }
    }
     //sqlReader.Dispose();
     //sqlReader.Close();
     //sqlConn.Close();
    
     SQLCmd.CommandText = "another query";
    //no need to open connection again.
    // sqlConn.Open();
    // sqlReader = SQLCmd.ExecuteReader();
    
     using(sqlReader = SQLCmd.ExecuteReader())
    {
       while (sqlReader.Read())
        {
        //some stuff here
        }
    }
     //sqlReader.Dispose();
     //sqlReader.Close();
     //sqlConn.Close();
