    try
    {
        using (SqlConnection connection = CreateSqlConnection(connString))
        {
                   using (SqlCommand command = CreateSqlCommand()
                   {
                       //open connection + execute command + do something else
                   }
        }
    }
    catch
    {
     //do something
    }
