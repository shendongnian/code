    using (SqlDatabaseClient client = SqlDatabaseManager.GetClient())
    {
        client.SetParameter("sender", mUsername);
        client.SetParameter("message", textBox1.Text);
        client.ExecuteNonQuery("INSERT INTO program_messages ('sender','message','timesent') VALUES (@sender,@message,GETDATE())");
    }
    updateneeded = 1;
