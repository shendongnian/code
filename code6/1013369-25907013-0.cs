     using System.Data.SqlClient;
     ......
    stringconnection = @"Data Source=(LocalDb)\\v11.0;Initial Catalog=Datatest;
                        Integrated Security=SSPI;";
    using(objconnection = new SqlConnection(stringconnection))
    {
        objconnection.Open();
        strSQL = "insert into users(username, name, email)values(@username, @name, @email)";
        using(objcmd = new SqlCommand(strSQL, objconnection))
        {
            objcmd.Parameters.Add(new SqlParameter("@username", strun));
            objcmd.Parameters.Add(new SqlParameter("@name", strna));
            objcmd.Parameters.Add(new SqlParameter("@email", strem));
            objcmd.ExecuteNonQuery();
        }
    }
    Response.Write("Entered Successfully");
