    public void Pollback()
    {
        Timer poller = new Timer(5000);
        poller.Elapsed += (s, e) => InsertMessage();
        poller.Start();  // "Start()" sets "Enabled = true", so you don't need the other statement
    }
    public void GsmPhone_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        InsertMessage();
    }
    private void InsertMessage()
    {
        Log("Message Received");
        try
        {
            using (var conn = new SqlConnection("Data Source=*********,****;Initial Catalog=******;User ID=********;Password=*******"))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = conn;
                    conn.Open();
                    com.CommandText = ("INSERT INTO My_Table(ID,Message,Blacklist) VALUES(2, @Message, 'Yes')");
                    com.Parameters.AddWithValue("@Message", GSM.ReadMessage(4).ToString());
                    com.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
        }
    }
