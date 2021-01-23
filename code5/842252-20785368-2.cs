        private int CopySchemas(string pathname)
        {
            int index = 0;
            MySqlConnection conn1 = new MySqlConnection(PublicVariables.cs);
            using (MySqlConnection conn = new MySqlConnection(PublicVariables.cs))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA='" + PublicVariables.DbName + "'", conn))
                {
                    conn.Open();
                    conn1.Open();
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string tblname = reader.GetValue(0).ToString();
                            MySqlCommand cmd1 = new MySqlCommand("SHOW CREATE TABLE " + PublicVariables.DbName + "." + tblname, conn1);
                            MySqlDataReader reader1 = cmd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                string fname = pathname + "\\" + reader1.GetValue(0).ToString() + ".sql";
                                string schema = reader1.GetValue(1).ToString();
                                File.WriteAllText(fname, schema);
                            }
                            reader1.Dispose();
                            ++index;
                        }
                    }
                    catch (MySqlException e)
                    {
                        MessageBox.Show(e.Number.ToString() + " -> " + e.Message.ToString());
                        return 0;
                    }
                }
            }
            return index;
         }
