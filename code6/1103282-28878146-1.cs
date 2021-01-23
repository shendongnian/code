    using (SQLiteConnection connect = new SQLiteConnection(mainDbPath))
    {
        connect.Open();
        using (var transaction = connect.BeginTransaction())
        {
            foreach (DataRow row in secondTable.Rows)
            {
                var cmdText= string.Format("INSERT INTO Messages VALUES ({0},'{1}','{2}');",
                    row["ID"], row["POSTERNAME"], row["MESSAGE"]);
    
                using (var cmd = new SQLiteCommand(cmdText, connect, transaction))
                {
                    cmd.ExecuteNonQuery();
                }
            }
    
            transaction.Commit();
        }
    }
