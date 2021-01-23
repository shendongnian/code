    private void button2_Click(object sender, EventArgs e)
        {
            String connString = "Data Source=" + Environment.CurrentDirectory + "\\UrduDictionary";
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
                           // Console.WriteLine(dr.GetValue(0) + " " + dr.GetValue(1) + " " + dr.GetValue(2));
                        }
                    }
                }
            }
            //Console.ReadLine();
        }
