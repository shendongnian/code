    public void Main_InsertAllDatas(int currentUser, List<PasswordData> input)
    {
        string insert = "INSERT INTO tbl_Data ([UserName],[Password],[Category],[Title],[Description],[UserID]) VALUES (@UserName,@Password,@Category,@Title,@Description,@UserID)";
        using (var MainConnection = new System.Data.OleDb.OleDbConnection("..."))
        using (var Command = new System.Data.OleDb.OleDbCommand(insert, MainConnection))
        {
            Command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@UserName", System.Data.OleDb.OleDbType.VarChar, 50));
            Command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Password", System.Data.OleDb.OleDbType.VarChar, 50));
            Command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Category", System.Data.OleDb.OleDbType.VarChar, 100));
            Command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Title", System.Data.OleDb.OleDbType.VarChar, 100));
            Command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Description", System.Data.OleDb.OleDbType.VarChar, 100));
            Command.Parameters.Add(new System.Data.OleDb.OleDbParameter("@UserID", System.Data.OleDb.OleDbType.Integer));
            MainConnection.Open();
            for (int i = 0; i < input.Count; i++)
            {
                Command.Parameters["@UserName"].Value = EncDecWorker.EncrypteString(input[i].Username, Key);
                // ...
                try
                {
                    MainConnection.Open();
                    int inserted = Command.ExecuteNonQuery();
                } catch (Exception)
                {
                    // log, show or do something else useful
                    throw; // better than an empty catch
                }
            }
        } // you don't need to close the connection with using
    }
