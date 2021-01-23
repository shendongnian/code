    private void button2_Click(object sender, EventArgs e)
    {
        string dbPath = Path.Combine(Environment.CurrentDirectory, "UrduDictionary");
        string connString = string.Format("Data Source={0}", dbPath);
        using (SQLiteConnection conn = new SQLiteConnection(connString))
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * ");
            query.Append("FROM CATIGORY_TABLE ");
            using (SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conn))
            {
                conn.Open();
                
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                            dr.GetValue(0),
                            dr.GetValue(1),
                            dr.GetValue(2));
                    }
                }
            }
        }
    }
