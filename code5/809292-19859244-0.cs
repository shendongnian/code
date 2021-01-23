    using (SqlDatabaseClient client = SqlDatabaseManager.GetClient())
    {
        int id = int.Parse(client.ExecuteScalar("SELECT COUNT(*) FROM program_messages").ToString());
        client.SetParameter("id", id + 1);
        // ...
        client.ExecuteNonQuery("INSERT INTO program_messages (`id`,`sender`,`message`,`timesent`) VALUES (@id,@sender,@message,@timesent)");
    }
    updateneeded = 1;
