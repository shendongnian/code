    using (OleDbConnection conn = new OleDbConnection(connString))
    {
        conn.Open();
        using(OleDbCommand cmd = new OleDbCommand("SELECT UserID FROM tblUser WHERE Username=@user AND Password = @pass", conn))
        {
            cmd.Parameters.AddWithValue("@user", user ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@pass", pass ?? DBNull.Value);
            int UserID = (int)cmd.ExecuteScalar();
            return UserID < 0 ? -1 : UserID;
        }
    }
