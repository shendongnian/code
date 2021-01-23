    public string top10()
    {
        List<string> toplist = new List<string>();
        String sql = "SELECT user FROM '" + channel + "' ORDER BY currency DESC LIMIT 10";
        using (cmd = new SQLiteCommand(sql, myDB))
        {
            using (SQLiteDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                     toplist.Add(r.GetString(0));
                }
            }
        }
        return string.Join(",", toplist);
    }
