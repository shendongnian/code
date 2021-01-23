    using (var sqlconnection = new SqlConnection())
    {
        using (var command = sqlconnection.CreateCommand())
        {
             command.CommandText = "If Object_ID('ServerName.dbo.ViewName', 'V') IS NOT NULL DROP VIEW 'ServerName.dbo.ViewName'";
             command.ExecuteNonQuery();
         }
     }
